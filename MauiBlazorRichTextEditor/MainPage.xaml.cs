namespace MauiBlazorRichTextEditor
{
    public partial class MainPage : ContentPage
    {
        private readonly ViewModel _viewModel;
        public MainPage(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;

        }
    }
}
