# TelegramBotWithConfig

This repository contains a simple .NET console application that demonstrates how to properly use configuration files (`appsettings.json`, environment-specific configs, and `IOptions<T>`) in C# projects.

## Article

This project is part of the article:  
**What's Wrong with Configs in C#?**  

> The article explains how to stop hardcoding secrets and start working with clean, flexible, and environment-specific configurations in .NET — using a real Telegram bot as an example.

---

## What’s inside

- Manual setup of `appsettings.json` in a console app
- Configuration loading with `ConfigurationBuilder`
- Auto-copying configs to output folder
- Clean `.gitignore` for safe development
- Ready-to-use sample config structure for Telegram bots

---

## Getting Started

```bash
git clone https://github.com/your-username/TelegramBotWithConfig.git
cd TelegramBotWithConfig
dotnet restore
dotnet run
```

Make sure to provide your own Telegram bot token inside `appsettings.json`.

---

## 📝 License

MIT — use freely, just don’t hardcode your secrets 😉
