using CurrencyFetcher.Adapters.Contracts;
using CurrencyFetcher.Controllers.Models;


namespace CurrencyFetcher.Adapters;
public class CurrencyAdapter
{
    private readonly HttpClient client;
    private readonly string baseUrl;

    public CurrencyAdapter(HttpClient client, string baseUrl)
    {
        if (client == null) throw new ArgumentException("client not set");
        this.client = client;

        if (string.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentException("baseUrl not set");
        this.baseUrl = baseUrl;
    }

    public async Task<Rates> GetRate(Curency baseCurrency, Curency targetCurrency) // , DateTime? historical
    {
        // https://api.apilayer.com/fixer/latest
        string url = $"https://{baseUrl}/fixer/latest?symbols={targetCurrency.Code}&base={baseCurrency.Code}";

        using (HttpResponseMessage response = await client.GetAsync(url))
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

    public async Task<SupportedCurencies> GetSupportedCurencies()
    {
        string url = $"https://{baseUrl}/fixer/symbols";
        using (HttpResponseMessage response = await client.GetAsync(url))
        {

            if (response.IsSuccessStatusCode)
            {
                Symbols result = await response.Content.ReadAsAsync<Symbols>();
                var supportedCurencies = new SupportedCurencies();
                supportedCurencies.Currencies = result.symbols.Select(x => new Curency
                {
                    Code = x.Key,
                    Name = x.Value
                }).ToList();
                return supportedCurencies;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

    }
}