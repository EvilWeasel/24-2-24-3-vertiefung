using Microsoft.Extensions.Logging;

namespace maui_einstieg;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        // Builder Pattern, siehe https://refactoring.guru/design-patterns/builder
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>() // App.xaml als Einstiegspunkt für MAUI App
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        // Compiler-Anweisung: Wenn DEBUG-Build, dann füge Logging-Service hinzu
#if DEBUG
        builder.Logging.AddDebug();
#endif
        // Baue und starte die MAUI-App
        return builder.Build();
    }
}
