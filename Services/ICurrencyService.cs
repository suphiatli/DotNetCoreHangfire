using System.Collections.Generic;
using DotNetCoreHangfire.Models;

namespace DotNetHangfire.Services
{
    public interface ICurrencyService
    {
        Dictionary<string, Currency> GetCurrencyRates ();
    }
}