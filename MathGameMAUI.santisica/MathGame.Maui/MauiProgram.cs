using MathGame.Maui.Data;
using Microsoft.Extensions.Logging;

namespace MathGame.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Orbitron.ttf","Orbitron");
                });

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "game.db");
            builder.Services.AddSingleton(s =>
                ActivatorUtilities.CreateInstance<GameRepository>(s, dbPath));

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
