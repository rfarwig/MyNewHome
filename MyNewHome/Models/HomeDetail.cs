using System;


namespace MyNewHome
{
    public class HomeDetail : ObservableObject
    {
        public string HomeDetailId { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public int GrossLivingArea { get; set; }
        public int LotSize { get; set; }

        public int ListingAmount { get; set; }
        public int DaysOnMarket { get; set; }
        public int CurrentAnnualPropertyTaxAmount { get; set; }


        public int OfferAmount { get; set; }
        public DateTime OfferDate { get; set; }

    }
}
