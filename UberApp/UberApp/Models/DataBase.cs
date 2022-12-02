using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UberApp.Models
{
    public class DataBase
    {
        private static readonly string baseUrl = "https://192.168.0.107:44358/Login/";
        private readonly HttpClient httpClient;

        public DataBase()
        {
            httpClient = new();
        }

        public async Task<bool> Check(string username)
        {
            var uri = new Uri(baseUrl);
            try
            {
                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return true;
        }
    }
}
