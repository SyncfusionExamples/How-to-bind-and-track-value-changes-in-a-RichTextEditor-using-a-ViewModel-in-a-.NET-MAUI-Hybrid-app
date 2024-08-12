namespace MauiBlazorRichTextEditor
{
    public partial class App : Application
    {
        public App(ViewModel viewModel)
        {            
            InitializeComponent();

            MainPage = new MainPage(viewModel);
        }
    }
}
