using maui_cerberus_pass.Views;

namespace maui_cerberus_pass
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Routing.RegisterRoute("DetailsPage", typeof(DetailsPage));
            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        }
    }
}
