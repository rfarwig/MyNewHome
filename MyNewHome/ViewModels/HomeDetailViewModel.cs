﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyNewHome
{
    public class HomeDetailViewModel : BaseViewModel
    {
        public HomeDetail HomeDetail { get; set; }

        public int ProjectedAnnualPropertyTaxAmount
        {
            get 
            {
                return (int)(HomeDetail.CurrentAnnualPropertyTaxAmount * .20);
            }

        }

        public string FormattedStreetAddress1
        {
            get
            {
                return string.Format("{0} {1}", HomeDetail.StreetAddress1, HomeDetail.StreetAddress2);
            }
        }

        public string FormattedStreetAddress2
        {
            get
            {
                return string.Format("{0}, {1} {2}", HomeDetail.City, HomeDetail.State, HomeDetail.ZipCode);
            }
        }

        public HomeDetailViewModel(HomeDetail homeDetail = null)
        {
            Title = homeDetail.StreetAddress1;
            HomeDetail = homeDetail;
        }

    }
}
