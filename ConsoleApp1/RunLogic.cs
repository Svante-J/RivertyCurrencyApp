using CurrencyFetcher.Controller;
using CurrencyFetcher.Models.Symbols;
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
        var avalibleCurrencyCodes = SymbolsProcessor.LoadAvalible();

        var thecodes = avalibleCurrencyCodes.Result.symbols;
        foreach (var code in thecodes!)
        {
            Console.Write(" " + code.Key);
        }
        do
        {

            Console.WriteLine("\ninput currency code ");
            currencyCodeInput = Console.ReadLine().ToUpper();
            if(thecodes!.ContainsKey(currencyCodeInput))
            {
                Console.WriteLine(thecodes.First(x => x.Key == currencyCodeInput).Value);
            }
            else
            {
                Console.WriteLine("not a avalible curency");
            }

        } while (!thecodes!.ContainsKey(currencyCodeInput));


        Console.WriteLine("\ninput ammount");
        var ammountInput = Console.ReadLine();
        Console.WriteLine("input currency to exchange");
        var secoundCurrency = "USD";



    }
}

//https://www.youtube.com/watch?v=Yi-O-HBGPeU
//    https://apilayer.com/marketplace/fixer-api