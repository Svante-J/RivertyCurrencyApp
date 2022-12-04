using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyFetcher.Utilitys;

public static class RateCalculator
{
    public static decimal ExchangeCurencies(decimal rate, decimal amount) => amount * rate;

}

