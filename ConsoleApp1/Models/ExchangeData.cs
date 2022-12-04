using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyFetcher.Models;

public class ExchangeData
{
    public string? BaseCurrency { get; set; }
    public decimal Amount { get; set; }
    public string TargetCurrency { get; set; }

}

