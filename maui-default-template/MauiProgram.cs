using Microsoft.Extensions.Logging;

namespace maui_default_template;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        // Builder-Pattern, siehe https://refactoring.guru/design-patterns/builder/csharp/example
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        // Compiler-Anweisung
        // Wenn ich einen Debug-Build mache, dann soll er detailiertes Logging hinzufügen
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
