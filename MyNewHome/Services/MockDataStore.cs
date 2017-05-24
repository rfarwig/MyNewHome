using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNewHome
{
    public class MockDataStore : IDataStore<HomeDetail>
    {
        //bool isInitialized;
        List<HomeDetail> items;

        public MockDataStore()
        {
            items = new List<HomeDetail>();
            var _items = new List<HomeDetail>
            {
                new HomeDetail { HomeDetailId = Guid.NewGuid().ToString(),
                    StreetAddress1 = "123 Main Street",
                    City = "Detroit",
                    State = "MI",
                    ZipCode = 48226,
                    ListingAmount=250000},

                new HomeDetail { HomeDetailId = Guid.NewGuid().ToString(),
                    StreetAddress1 = "345 Kerby Rd",
                    City = "Detroit",
                    State = "MI",
                    ZipCode = 48226,
                    ListingAmount=350000},
                new HomeDetail { HomeDetailId = Guid.NewGuid().ToString(),
                    StreetAddress1 = "3456 Purchase Street",
                    City = "Detroit",
                    State = "MI",
                    ZipCode = 48226,
                    ListingAmount=237000}
            };

            foreach (HomeDetail item in _items)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(HomeDetail item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(HomeDetail item)
        {
            var _item = items.Where((HomeDetail arg) => arg.HomeDetailId == item.HomeDetailId).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((HomeDetail arg) => arg.HomeDetailId == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<HomeDetail> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.HomeDetailId == id));
        }

        public async Task<IEnumerable<HomeDetail>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
