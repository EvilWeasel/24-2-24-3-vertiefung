using maui_mvvm.Service;
using maui_mvvm.View;
using maui_mvvm.ViewModel;
using Microsoft.Extensions.Logging;

namespace maui_mvvm;

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

		// Dependency-Injection für Services
		builder.Services.AddSingleton<PeopleService>();

		// Dependency-Injection für ViewModels
		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<PeopleViewModel>();

		//MainPage startupPage = new MainPage(new MainViewModel(new PeopleService()));


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
