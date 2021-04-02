using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyExchanger.DataModel;

namespace CurrencyExchanger
{
    public class ConvertCurrency
    {
        public float GetConvertResult(DateTime convertingDate, float initVal = 1.0f, string initCurrencyName = "RUB", string resultCurrencyName = "RUB")
        {
            float initCurrencyPerOne = 1.0f, resultCurrencyPerOne = 1.0f;

            using (CurrencyContext context = new CurrencyContext())
            {
                if (initCurrencyName != "RUB")
                {
                    CurrencyHistory initHist = context.CurrencyHistories
                        .Where(x => x.Date == convertingDate.Date && x.Currency.ISOCharCode == initCurrencyName)
                        .OrderByDescending(x => x.HistoryId).FirstOrDefault();

                    if (initHist != null) initCurrencyPerOne = initHist.Value / initHist.Nominal;
                }

                if (resultCurrencyName != "RUB")
                {
                    CurrencyHistory resultHist = context.CurrencyHistories
                        .Where(x => x.Date == convertingDate.Date && x.Currency.ISOCharCode == resultCurrencyName)
                        .OrderByDescending(x => x.HistoryId).FirstOrDefault();

                    if (resultHist != null) resultCurrencyPerOne = resultHist.Value / resultHist.Nominal;
                }
            }

            return initVal * initCurrencyPerOne / resultCurrencyPerOne;
        }
    }
}