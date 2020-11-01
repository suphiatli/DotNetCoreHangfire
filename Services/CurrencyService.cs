using System;
using System.Collections.Generic;
using System.Xml;
using DotNetCoreHangfire.Models;

namespace DotNetHangfire.Services
{
    public class CurrencyService: ICurrencyService
    {
        public CurrencyService() { } 


        public Dictionary<string, Currency> GetCurrencyRates () 
        {
            XmlTextReader rdr = new XmlTextReader ("http://www.tcmb.gov.tr/kurlar/today.xml");

            XmlDocument myxml = new XmlDocument ();

            myxml.Load (rdr);

            XmlNode tarih = myxml.SelectSingleNode ("/Tarih_Date/@Tarih");

            XmlNodeList mylist = myxml.SelectNodes ("/Tarih_Date/Currency");

            XmlNodeList adi = myxml.SelectNodes ("/Tarih_Date/Currency/Isim");

            XmlNodeList kod = myxml.SelectNodes ("/Tarih_Date/Currency/@Kod");

            XmlNodeList doviz_alis = myxml.SelectNodes ("/Tarih_Date/Currency/ForexBuying");

            XmlNodeList doviz_satis = myxml.SelectNodes ("/Tarih_Date/Currency/ForexSelling");

            XmlNodeList efektif_alis = myxml.SelectNodes ("/Tarih_Date/Currency/BanknoteBuying");

            XmlNodeList efektif_satis = myxml.SelectNodes ("/Tarih_Date/Currency/BanknoteSelling");

            Dictionary<string, Currency> ExchangeRates = new Dictionary<string, Currency>
            {
                { "TRY", new Currency("Türk Lirası", "TRY", "TRY/TRY", 1, 1, 1, 1) }
            };


            for (int i = 0; i < adi.Count; i++) {

                Currency cur = new Currency (adi.Item (i).InnerText.ToString (),

                    kod.Item (i).InnerText.ToString (),

                    kod.Item (i).InnerText.ToString () + "/TRY",

                    (String.IsNullOrWhiteSpace (doviz_alis.Item (i).InnerText.ToString ())) ? 0 : Convert.ToDecimal (doviz_alis.Item (i).InnerText.ToString ()),

                    (String.IsNullOrWhiteSpace (doviz_satis.Item (i).InnerText.ToString ())) ? 0 : Convert.ToDecimal (doviz_satis.Item (i).InnerText.ToString ()),

                    (String.IsNullOrWhiteSpace (efektif_alis.Item (i).InnerText.ToString ())) ? 0 : Convert.ToDecimal (efektif_alis.Item (i).InnerText.ToString ()),

                    (String.IsNullOrWhiteSpace (efektif_satis.Item (i).InnerText.ToString ())) ? 0 : Convert.ToDecimal (efektif_satis.Item (i).InnerText.ToString ())

                );

                ExchangeRates.Add (kod.Item (i).InnerText.ToString (), cur);
            }
            return ExchangeRates;
        }
    }
}