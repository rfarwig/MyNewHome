using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyNewHome
{
    public class HomesViewModel : BaseViewModel
    {
        public ObservableRangeCollection<HomeDetail> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public HomesViewModel()
        {
            Title = "Browse";
            Items = new ObservableRangeCollection<HomeDetail>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewHomePage, HomeDetail>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as HomeDetail;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
