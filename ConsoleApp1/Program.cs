using CurrencyFetcher.Controllers;
using CurrencyFetcher.Adapters;
using CurrencyFetcher.Utilitys;
using System.Net.Http.Headers;

var apiKey = Environment.GetEnvironmentVariable("apikey");
if (apiKey == null)
{
    Console.WriteLine("apikey not present in env variables");
    return;
}

var domain = Environment.GetEnvironmentVariable("domain");
if (domain == null)
{
    Console.WriteLine("domain not present in env variables");
    return;
}


var client = new HttpClient();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
client.DefaultRequestHeaders.Add("apikey", apiKey);

var adapter = new CurrencyAdapter(client, domain);
var controller = new ConsoleController(adapter);
await controller.Run();