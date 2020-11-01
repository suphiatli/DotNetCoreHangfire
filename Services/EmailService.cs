using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using DotNetCoreHangfire.Models;

namespace DotNetHangfire.Services
{
    public class EmailService: IEmailService
    {
        public bool SendReport(Dictionary<string, Currency> currencyies)
         {
            try
            { 
                var fromAddress = new MailAddress("your email", "Sender");
                var toAddress = new MailAddress("reciever email", "Reciever");
                string fromPassword = "your email password";
                string subject = "Currency Rates, Date :" + DateTime.Now; 
                
                var body = string.Empty;
                foreach (var item in currencyies.Values)
                {
                    body += "<b>Name: </b>" + item.Name+ " <b>Code: </b>" + item.Code + " <b>Buying: </b>" + item.ForexBuying + " <b>Selling: </b>" + item.ForexSelling + "<br/><br/>";
                }
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                return true;
            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            } 
        }
    }
}