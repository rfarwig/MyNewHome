using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace MyNewHome
{
    public class CloudDataStore : IDataStore<HomeDetail>
    {
        HttpClient client;
        IEnumerable<HomeDetail> items;

        public CloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            items = new List<HomeDetail>();
        }

        public async Task<IEnumerable<HomeDetail>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/item");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<HomeDetail>>(json));
            }

            return items;
        }

        public async Task<HomeDetail> GetItemAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/item/{id}");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<HomeDetail>>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(HomeDetail item)
        {
            if (item == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> UpdateItemAsync(HomeDetail item)
        {
            if (item == null || item.HomeDetailId == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/item/{item.HomeDetailId}"), byteContent);

            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode ? true : false;
        }
    }
}
