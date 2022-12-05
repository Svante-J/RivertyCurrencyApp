using CurrencyFetcher.Models;
using CurrencyFetcher.Models.Symbols;
using CurrencyFetcher.Utilitys;

namespace CurrencyFetcher.Controller;
public class RateProcessor
{
    public static async Task<Rates> GetRate(string baseCurrency, string targetCurrency) // , DateTime? historical
    {
        string url = $"https://api.apilayer.com/fixer/latest?symbols={targetCurrency}&base={baseCurrency}";       

        using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
        {

            if (response.IsSuccessStatusCode)
            {
                Rates result = await response.Content.ReadAsAsync<Rates>();
                return result;                
                //return result.rates.FirstOrDefault(x => x.Value);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}