using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyFetcher.Adapters.Contracts;

public class Symbols
{
    public bool Success { set; get; }
    public Dictionary<string, string>? symbols { set; get; }
}