using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyNewHome
{
    public partial class HomeDetailPage : ContentPage
    {
        HomeDetailViewModel viewModel;

        public HomeDetailPage(HomeDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
