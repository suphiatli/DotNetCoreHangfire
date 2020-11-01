namespace DotNetHangfire.Services
{
    public class CurrencyRatesService
    {
        private readonly ICurrencyService currencyService;
        private readonly IEmailService emailService;
        public CurrencyRatesService()
        {
            currencyService = new CurrencyService();
            emailService = new EmailService();
        }

        public bool CurrencyRates()
        { 
            var currencyList = currencyService.GetCurrencyRates(); 
            bool isSuccess = emailService.SendReport(currencyList);
            return isSuccess;
        }
    }
}