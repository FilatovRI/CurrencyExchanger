using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CurrencyExchanger.DataModel;
using CurrencyExchanger.XMLModels;

namespace CurrencyExchanger
{
    public class FillDB
    {
        /// Заполнение списка валют
        public void FillCurrency()
        {
            using (CurrencyContext context = new CurrencyContext())
            {
                string xml = string.Empty;
                WebClient downloadClient = new WebClient();

                xml = downloadClient.DownloadString(new Uri($"http://www.cbr.ru/scripts/XML_valFull.asp"));

                Valuta valutes;
                XmlSerializer serializer = new XmlSerializer(typeof(Valuta));
                using (StringReader reader = new StringReader(xml))
                {
                    valutes = (Valuta)serializer.Deserialize(reader);
                }

                foreach (var valute in valutes.Item)
                {
                    CurrencyInfo currency = new CurrencyInfo
                    {
                        Nominal = valute.Nominal,
                        ParentCode = valute.ParentCode.Trim(),
                        EngName = valute.EngName,
                        ISONumCode = string.IsNullOrEmpty(valute.ISO_Num_Code) ? 0 : Convert.ToInt32(valute.ISO_Num_Code),
                        ISOCharCode = valute.ISO_Char_Code,
                        ID = valute.ID.Trim(),
                        Name = valute.Name
                    };
                    context.CurrencyInfo.Add(currency);
                }
                context.SaveChanges();
            }
        }

        /// Заполнение коэффициентов
        public void FillHistory(DateTime dt)
        {
            using (CurrencyContext context = new CurrencyContext())
            {
                string xml;
                WebClient downloadClient = new WebClient();

                xml = downloadClient.DownloadString(new Uri($"http://www.cbr.ru/scripts/XML_daily.asp?date_req={dt:dd.MM.yyyy}"));

                ValCurs valCurs = new ValCurs();
                XmlSerializer serializer = new XmlSerializer(typeof(ValCurs));
                using (StringReader reader = new StringReader(xml))
                {
                    valCurs = (ValCurs)serializer.Deserialize(reader);
                }

                foreach (var valute in valCurs.Valute)
                {
                    CurrencyHistory curHist = new CurrencyHistory
                    {
                        Date = DateTime.Parse(valCurs.Date),
                        Currency = context.CurrencyInfo.FirstOrDefault(x => x.ISOCharCode == valute.CharCode),
                        Value = float.Parse(valute.Value.Replace(',', '.'), CultureInfo.InvariantCulture.NumberFormat),
                        Nominal = Convert.ToInt32(valute.Nominal)
                    };
                    context.CurrencyHistories.Add(curHist);
                }
                context.SaveChanges();
            }
        }
    }
}
