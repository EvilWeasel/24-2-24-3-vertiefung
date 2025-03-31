﻿using BuchverkaufBinder.Service;
using BuchverkaufBinder.View;
using BuchverkaufBinder.ViewModel;
using Microsoft.Extensions.Logging;

namespace BuchverkaufBinder
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
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            // Dependency-Injection Views
            builder.Services.AddSingleton<BookCollectionView>();
            builder.Services.AddSingleton<CategoryView>();
            builder.Services.AddTransient<BookDetailsView>();
            // Dependency-Injection ViewModels
            builder.Services.AddSingleton<BookCollectionViewModel>();
            builder.Services.AddSingleton<CategoryViewModel>();
            builder.Services.AddTransient<BookDetailsViewModel>();
            // Dependency-Injection Services
            builder.Services.AddSingleton<BookService>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
