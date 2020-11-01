using System.Collections.Generic;
using DotNetCoreHangfire.Models;

namespace DotNetHangfire.Services
{
    public interface IEmailService
    {
         bool SendReport(Dictionary<string, Currency> currencyList);
    }
}