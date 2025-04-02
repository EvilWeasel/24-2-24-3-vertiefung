using BuchverkaufBinder.Data;
using BuchverkaufBinder.Service;
using BuchverkaufBinder.View;
using BuchverkaufBinder.ViewModel;
using Microsoft.EntityFrameworkCore;
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
            var appDataDir = FileSystem.Current.AppDataDirectory;
            var dbPath = Path.Join(appDataDir, "binder.db");

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
            // Dependency-Injection for DbContext
            //builder.Services.AddDbContext<BookContext>(options =>
            //{
            //    options.UseSqlite($"Data Source={dbPath}");
            //});
            builder.Services.AddDbContext<BookContext>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
