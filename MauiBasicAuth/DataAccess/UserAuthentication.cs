using System.Net.Http.Headers;
using System.Text;

namespace MauiBasicAuth.DataAccess
{
    public class UserAuthentication
    {
        public async Task<bool> AuthenticateUserAsync(
            string username,
            string password)
        {
            using var client = new HttpClient();

            client.BaseAddress =
                new Uri("http://localhost:5076/");

            var credentials =
                $"{username}:{password}";

            var authToken =
                Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(credentials));

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Basic",
                    authToken);

            var response =
                await client.GetAsync("api/Values");

            return response.IsSuccessStatusCode;
        }
    }
}