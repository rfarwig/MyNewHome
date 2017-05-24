using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyNewHome
{
    public partial class NewHomePage : ContentPage
    {
        public HomeDetail Item { get; set; }

        public NewHomePage()
        {
            InitializeComponent();

            Item = new HomeDetail
            {
                StreetAddress1 = "Item name",
                ListingAmount = 0
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopToRootAsync();
        }
    }
}
