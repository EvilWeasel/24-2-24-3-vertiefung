﻿using cerberus_pass_maui.ViewModel;
using Microsoft.Extensions.Logging;
using password_manager;

namespace cerberus_pass_maui;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif
        // ViewModels
        builder.Services.AddSingleton<MainPageViewModel>();
        // Services
        builder.Services.AddSingleton<PasswordManager>();
        return builder.Build();
    }
}
