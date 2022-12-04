using CurrencyFetcher.Models.Symbols;
using CurrencyFetcher.Utilitys;
using System.Net.Http.Json;

namespace CurrencyFetcher.Controller;

public class SymbolsProcessor
{
    public static async Task<Symbols> LoadAvalible()
    {
        string url = "https://api.apilayer.com/fixer/symbols";
        //ApiHelper.ApiClient.DefaultRequestHeaders.Add("apikey", "CBJa0LZQ6xa4eUOA691MxSrpajfJwGbD");

        using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
        {

            if (response.IsSuccessStatusCode)
            {
                Symbols result = await response.Content.ReadAsAsync<Symbols>();
                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}



