using Microsoft.Extensions.Configuration;

namespace TgBotWithConfig;
internal class Program
{
    private static async Task Main(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true)
            .Build();

        var token = config["Telegram:BotToken"];
        if (string.IsNullOrEmpty(token))
        {
            Console.WriteLine("Bot token is not configured.");
            return;
        }

        var botService = new TelegramBotService(token);
        await botService.StartAsync();

        Console.ReadLine();
        botService.Stop();
    }
}