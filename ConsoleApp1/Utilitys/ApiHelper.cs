using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyFetcher.Utilitys;

public class ApiHelper
{
    public static HttpClient ApiClient { get; set; } = new HttpClient();
    public static string key = "CBJa0LZQ6xa4eUOA691MxSrpajfJwGbD";
    
    public static void InitializeClient()
    {
        ApiClient = new HttpClient();
        ApiClient.DefaultRequestHeaders.Accept.Clear();
        ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("apikey", "CBJa0LZQ6xa4eUOA691MxSrpajfJwGbD");
        //ApiClient.DefaultRequestHeaders.Add("apikey", "CBJa0LZQ6xa4eUOA691MxSrpajfJwGbD");
        //ApiClient.DefaultRequestHeaders.Add("apikey", "CBJa0LZQ6xa4eUOA691MxSrpajfJwGbD");
        //
        //var header = new AuthenticationHeaderValue("apikey", key);
        //ApiClient.DefaultRequestHeaders.Authorization = header;           
    }

}

