using System.Collections.ObjectModel;

namespace maui_simple
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> TodoItems { get; } = [];
        public string NewTodo { get; set; } = string.Empty;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            TodoItems.Add("Einkaufen gehen");
            TodoItems.Add("Oma besuchen");
            TodoItems.Add("Berliner essen");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewTodo))
                return;
            TodoItems.Add(NewTodo);
        }
    }

}
