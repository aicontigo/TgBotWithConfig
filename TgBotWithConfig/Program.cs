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

        var telegramConfiguration = new TelegramConfiguration();
        config.GetSection("Telegram").Bind(telegramConfiguration);
        

        var botService = new TelegramBotService(telegramConfiguration);
        await botService.StartAsync();

        Console.ReadLine();
        botService.Stop();
    }
}