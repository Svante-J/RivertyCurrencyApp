using CurrencyFetcher.Models;
using CurrencyFetcher.Models.Symbols;
using CurrencyFetcher.Utilitys;

namespace CurrencyFetcher.Controller;
public class RateProcessor
{
    public static async Task<Rates> GetRate(string baseCurrency, string targetCurrency, DateTime? historical)
    {
        string url = $"https://api.apilayer.com/fixer/latest?symbols={targetCurrency}&base={baseCurrency}";
        ApiHelper.ApiClient.DefaultRequestHeaders.Add("apikey", "CBJa0LZQ6xa4eUOA691MxSrpajfJwGbD");

        using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
        {

            if (response.IsSuccessStatusCode)
            {
                Rates result = await response.Content.ReadAsAsync<Rates>();
                return result.rates.FirstOrDefault(x => x.Value);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
} 