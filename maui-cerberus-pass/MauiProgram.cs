using CommunityToolkit.Maui;
using maui_cerberus_pass.ViewModels;
using maui_cerberus_pass.Views;
using Microsoft.Extensions.Logging;
using password_manager_toolkit;

namespace maui_cerberus_pass;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Dependency-Injection Services
		builder.Services.AddSingleton<PasswordManager>();
		
		// Dependency-Injection ViewModels
		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddTransient<DetailsViewModel>();

		// Dependency-Injection Views
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<DetailsPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
