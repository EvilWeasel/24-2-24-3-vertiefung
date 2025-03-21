using CommunityToolkit.Maui;
using maui_cerberus_pass.Services;
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

		var appDataDir = FileSystem.Current.AppDataDirectory;

		// Dependency-Injection Services
		builder.Services.AddSingleton<PasswordManager>(s => 
			new PasswordManager(appDataDir));
		builder.Services.AddSingleton<PromptService>();
		
		// Dependency-Injection ViewModels
		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddTransient<DetailsViewModel>();
		builder.Services.AddTransient<AddEntryViewModel>();

		// Dependency-Injection Views
		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<DetailsPage>();
		builder.Services.AddTransient<AddEntryPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
