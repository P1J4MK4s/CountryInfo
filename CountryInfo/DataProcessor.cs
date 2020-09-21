using Microsoft.Xrm.Sdk.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CountryInfo
{

    public static class DataProcessor
    {
        public static List<T> Deserialize<T>(this string SerializedJSONString)
        {
            var stuff = JsonConvert.DeserializeObject<List<T>>(SerializedJSONString);
            return stuff;
        }
        public static async Task<CountryModel> LoadData(string countryName = "Ukrain")
        {
            string url = $"https://restcountries.eu/rest/v2/name/{ countryName}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    CountryModel country = await response.Content.ReadAsAsync<CountryModel>();
                    Console.Write(countryName);
                    return country;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
