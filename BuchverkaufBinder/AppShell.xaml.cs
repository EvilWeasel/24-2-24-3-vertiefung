using BuchverkaufBinder.View;

namespace BuchverkaufBinder
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Routing.RegisterRoute("BookDetailsView", BuchverkaufBinder.View.BookDetailsView)
            Routing.RegisterRoute(nameof(BookDetailsView), typeof(BookDetailsView));
        }
    }
}
