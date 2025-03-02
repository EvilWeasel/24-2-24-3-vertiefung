namespace maui_einstieg
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        /* 
         * Initialisiere die App-Shell in AppShell.xaml
         * Wird automatisch ausgeführt durch den Builder
        */
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}