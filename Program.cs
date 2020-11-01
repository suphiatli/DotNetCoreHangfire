using DotNetHangfire;
using DotNetHangfire.Services;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Owin.Hosting;
using System;

namespace DotNetHanfire
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfiguration.Configuration.UseMemoryStorage();
            var options = new StartOptions();
            options.Urls.Add("http://localhost:8081");
            WebApp.Start<Startup>(options);
            Console.WriteLine("{0} Hangfire dashboard is available at {1}/hangfire", DateTime.Now, "http://localhost:8081");

            RecurringJob.AddOrUpdate("CurrencyRates", () => new CurrencyRatesService().CurrencyRates(), "*/2 * * * *"); //every 2 minutes
            Console.ReadLine();
            Console.WriteLine("hangfire job run gracefull");
        }
    }
}
