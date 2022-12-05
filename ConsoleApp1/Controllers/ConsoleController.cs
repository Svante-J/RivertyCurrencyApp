using CurrencyFetcher.Adapters;
using CurrencyFetcher.Controllers.Models;
using CurrencyFetcher.Utilitys;

namespace CurrencyFetcher.Controllers;

public class ConsoleController
{
    private readonly CurrencyAdapter currencyAdapter;

    public ConsoleController(CurrencyAdapter adapter)
    {
        if (adapter == null) throw new ArgumentNullException();
        this.currencyAdapter = adapter;
    }

    public async Task Run()
    {
        var avalibleCurrencies = await currencyAdapter.GetSupportedCurencies();
        foreach (var currency in avalibleCurrencies.Currencies!)
        {
            Console.Write(" " + currency.Code); // ToDo Snygga till
        }


        var baseCurrency = SetCurrency(avalibleCurrencies, "Input currency code");
        var amount = SetAmount();
        var targetCurrency = SetCurrency(avalibleCurrencies, "input target currency for exchange");

        var result = await currencyAdapter.GetRate(baseCurrency!, targetCurrency!); // ToDo 
        var rate = result.rates!.FirstOrDefault().Value;
        var calculatedValue = RateCalculator.ExchangeCurencies(rate, amount);

        Console.WriteLine(baseCurrency + " amount " + amount +
            " rate " + rate + " convert to " + targetCurrency + " = " + calculatedValue);
    }

    private decimal SetAmount()
    {
        Console.WriteLine("\ninput ammount to exchange");
        decimal amount;
        do
        {
            if (decimal.TryParse(Console.ReadLine(), out amount) && amount >= 0)
            {
                Console.WriteLine("amount is set to " + amount);
                return amount;
            }
            else
            {
                Console.WriteLine("not a valid amount. PLease try again");
            }
        } while (true);

    }

    private Curency SetCurrency(SupportedCurencies supported, string inputMessage)
    {
        do
        {

            Console.WriteLine();
            Console.WriteLine(inputMessage);
            var currency = supported.GetCurrency(Console.ReadLine()!);
            if (currency != null)
            {
                Console.WriteLine($"{currency.Name} selected via {currency.Code}");
                return currency;
            }

            else
            {
                Console.WriteLine("not a avalible curency");
            }

        } while (true);

    }
}