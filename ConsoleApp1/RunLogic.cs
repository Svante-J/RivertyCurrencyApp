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
    private static string? baseCurrency;
    private static decimal amount;
    private static string? targetCurrency;

    public static void Run()
    {

        var apiResponse = SymbolsProcessor.LoadAvalibleCurrencies();
        var avalibleCurrencyCodes = apiResponse.Result.symbols;
        foreach (var code in avalibleCurrencyCodes!)
        {
            Console.Write(" " + code.Key);
        }

        SetBaseCurrency(avalibleCurrencyCodes);
        SetAmount();
        SetTagetCurrency(avalibleCurrencyCodes);

        var result = RateProcessor.GetRate(baseCurrency!, targetCurrency!);
        var rate = result.Result.rates!.FirstOrDefault().Value;
        var calculatedValue = RateCalculator.ExchangeCurencies(rate, amount);
        Console.WriteLine(baseCurrency + " amount " + amount +
            " rate " + rate + " convert to " + targetCurrency + " = " + calculatedValue);
    }

    private static void SetTagetCurrency(Dictionary<string, string>? symbols)
    {
        do
        {

            Console.WriteLine("input target currency for exchange");
            targetCurrency = Console.ReadLine()!.ToUpper();
            if (symbols!.ContainsKey(targetCurrency))
            {
                symbols.TryGetValue(targetCurrency, out var currency);
                Console.WriteLine(currency + " selected");
            }
            else
            {
                Console.WriteLine("not a avalible curency");
            }
        } while (!symbols!.ContainsKey(baseCurrency));
    }

    private static void SetAmount()
    {
        Console.WriteLine("\ninput ammount to exchange");
        var succes = false;
        do
        {
            if (Decimal.TryParse(Console.ReadLine(), out amount) && amount >= 0)
            {
                Console.WriteLine("amount is set to " + amount);
                succes = true;
            }
            else
            {
                Console.WriteLine("not a valid amount. PLease try again");
            }
        } while (!succes);

    }

    private static void SetBaseCurrency(Dictionary<string, string>? symbols)
    {
        do
        {

            Console.WriteLine("\nInput currency code ");
            baseCurrency = Console.ReadLine()!.ToUpper();
            if (symbols!.ContainsKey(baseCurrency))
            {
                Console.WriteLine(symbols.First(x => x.Key == baseCurrency).Value + " selected");
            }

            else
            {
                Console.WriteLine("not a avalible curency");
            }

        } while (!symbols!.ContainsKey(baseCurrency));

    }
}
