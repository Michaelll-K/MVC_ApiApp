using MVC_ApiApp.Models;
using Newtonsoft.Json;

namespace MVC_ApiApp.Tools
{
    public class CountryManager
    {
        //Create HttpClient and set URI
        private HttpClient client;
        public CountryManager()
        {
            Uri address = new Uri("https://api.covid19api.com/summary");
            client = new HttpClient();
            client.BaseAddress = address;
        }

        /// <summary>
        /// Retrives JSON data from public API and transforms it to list
        /// </summary>
        /// <returns>List of CountryModel</returns>
        public List<CountryModel> GetCountries()
        {
            List<CountryModel> output;

            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                data = data.Substring(data.IndexOf('['));
                data = data.Remove(data.IndexOf("]") + 1);
                System.Diagnostics.Debug.WriteLine(data);
                output = JsonConvert.DeserializeObject<List<CountryModel>>(data);
                return output;
            }
            else
                return new List<CountryModel>();
        }
    }
}
