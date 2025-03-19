using maui_cerberus_pass.ViewModels;
using Microsoft.Extensions.Logging;

namespace maui_cerberus_pass;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Dependency-Injection Services

		// Dependency-Injection ViewModels
		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<DetailsViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
