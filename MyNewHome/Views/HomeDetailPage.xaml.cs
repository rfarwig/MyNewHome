using Xamarin.Forms;

namespace MyNewHome
{
    public partial class HomeDetailPage : ContentPage
    {
        HomeDetailViewModel _viewModel;

        public HomeDetailPage(HomeDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }
    }
}
