using MauiBasicAuth.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace MauiBasicAuth.DataAccess
{
    public class ApiService
    {
        private readonly HttpClient client;

        public ApiService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5076/")
            };
        }

        public async Task<bool> AuthenticateUserAsync(
            string username,
            string password)
        {
            var credentials = $"{username}:{password}";

            var token = Convert.ToBase64String(
                Encoding.UTF8.GetBytes(credentials));

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Basic",
                    token);

            var response =
                await client.GetAsync("api/Values");

            client.DefaultRequestHeaders.Authorization = null;

            return response.IsSuccessStatusCode;
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            return await client.GetFromJsonAsync<List<Item>>(
                "api/Items") ?? new List<Item>();
        }

        public async Task<bool> SaveItemAsync(Item item)
        {
            var response =
                await client.PostAsJsonAsync(
                    "api/Items",
                    item);

            return response.IsSuccessStatusCode;
        }
    }
}