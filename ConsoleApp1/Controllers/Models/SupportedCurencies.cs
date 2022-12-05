using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyFetcher.Controllers.Models;

public class SupportedCurencies
{
    public List<Curency> Currencies { get; set; }

    public SupportedCurencies()
    {
        Currencies = new List<Curency>();
    }

    public bool IsCodeSupported(string code)
    {
        return Currencies.Any(x => x.Code == code.ToUpper());
    }

    public Curency? GetCurrency(string code)
    {
        return Currencies.FirstOrDefault(x => x.Code == code.ToUpper());
    }
}
