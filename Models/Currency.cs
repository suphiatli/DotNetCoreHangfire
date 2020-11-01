using System;

namespace DotNetCoreHangfire.Models
{
   [Serializable]

    public class Currency

    {
        public Currency()
        {
        }

        public string Name { get; }

        public string Code { get; set;}

        public string CrossRateName { get; }

        public decimal ForexBuying { get; }

        public decimal ForexSelling { get; }

        public decimal BanknoteBuying { get; }

        public decimal BanknoteSelling { get; }

        public Currency (string name, string code, string crossRateName, decimal forexBuying, decimal forexSelling, decimal banknoteBuying, decimal banknoteSelling) {

            Name = name;

            Code = code;

            CrossRateName = crossRateName;

            ForexBuying = forexBuying;

            ForexSelling = forexSelling;

            BanknoteBuying = banknoteBuying;

            BanknoteSelling = banknoteSelling;
        }

    }
}