using CurrencyFetcher.Controller;
using CurrencyFetcher.Models.Symbols;
using CurrencyFetcher.Utilitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyFetcher;

public class RunLogic
{
    
    private static string? currencyCodeInput;

    public static void Run()
    {
        var result = RateProcessor.GetRate("USD", "EUR");

        var rate = result.Result.rates!.FirstOrDefault().Value;

        var calculatedValue = RateCalculator.ExchangeCurencies(rate, 100);


        var avalibleCurrencyCodes = SymbolsProcessor.LoadAvalible();

        var thecodes = avalibleCurrencyCodes.Result.symbols;
        foreach (var code in thecodes!)
        {
            Console.Write(" " + code.Key);
        }

        SetBaseCurrency(thecodes);

        Console.WriteLine("\ninput ammount");
        var ammountInput = Console.ReadLine();
        Console.WriteLine("input currency to exchange");
        var secoundCurrency = "USD";



    }

    private static string SetBaseCurrency(Dictionary<string, string>? thecodes)
    {
        do
        {

            Console.WriteLine("\nInput currency code ");
            currencyCodeInput = Console.ReadLine().ToUpper();
            if (thecodes!.ContainsKey(currencyCodeInput))
            {
                Console.WriteLine(thecodes.First(x => x.Key == currencyCodeInput).Value + "Selected");
            }
            else
            {
                Console.WriteLine("not a avalible curency");
            }

        } while (!thecodes!.ContainsKey(currencyCodeInput));

        // return thecodes.TryGetValue(currencyCodeInput, value); ToDo denna ovan
        return "";
    }
}
