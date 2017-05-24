using System;
using Xamarin.Forms;

namespace MyNewHome
{
    public partial class HomesPage : ContentPage
    {
        private readonly HomesViewModel _viewModel;

        public HomesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new HomesViewModel();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as HomeDetail;
            if (item == null)
                return;

            await Navigation.PushAsync(new HomeDetailPage(new HomeDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewHomePage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Items.Count == 0)
                _viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
