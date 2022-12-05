using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyFetcher.Adapters.Contracts;

public class Rates
{
    public Dictionary<string, decimal>? rates { set; get; }
}

