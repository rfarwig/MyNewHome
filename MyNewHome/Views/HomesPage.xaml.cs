using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyNewHome
{
    public partial class HomesPage : ContentPage
    {
        HomesViewModel viewModel;

        public HomesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new HomesViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as HomeDetail;
            if (item == null)
                return;

            await Navigation.PushAsync(new HomeDetailPage(new HomeDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewHomePage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
