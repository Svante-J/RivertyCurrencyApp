using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyFetcher.Models;

public class Rates
{
    public Dictionary<string, decimal>? rates { set; get; }
}

