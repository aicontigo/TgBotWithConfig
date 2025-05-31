using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TgBotWithConfig;

internal class TelegramBotService
{
    private readonly string _token;
    private TelegramBotClient? _botClient;
    private CancellationTokenSource? _cts;

    public TelegramBotService(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("Token cannot be null or empty.", nameof(token));

        _token = token;
    }

    public async Task StartAsync()
    {
        _botClient = new TelegramBotClient(_token);
        _cts = new CancellationTokenSource();

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        _botClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            receiverOptions,
            cancellationToken: _cts.Token
        );

        var me = await _botClient.GetMe();
        Console.WriteLine($"Bot started: @{me.Username}");
    }

    public void Stop()
    {
        _cts?.Cancel();
    }

    private async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken token)
    {
        if (update.Type != UpdateType.Message || update.Message?.Text == null)
            return;

        var chatId = update.Message.Chat.Id;
        var messageText = update.Message.Text;

        Console.WriteLine($"Received message: {messageText}");
        await bot.SendMessage(chatId, messageText, cancellationToken: token);
    }

    private Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken token)
    {
        Console.WriteLine($"Error: {exception.Message}");
        return Task.CompletedTask;
    }
}
