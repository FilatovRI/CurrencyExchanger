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
    class Program
    {
        static void Main(string[] args)
        {
            //// 1. Заполнение БД
            //FillDB fillDb = new FillDB();

            //// 1.1. Начальное заполнение таблицы Валют
            //fillDb.FillCurrency();

            //// 1.2. Начальное заполнение таблицы Истории (возможно указать диапазон дат)
            //DateTime dtFrom = new DateTime(2021, 03, 30);
            //DateTime dtTo = new DateTime(2021, 04, 01);
            //List<DateTime> dateRange = new List<DateTime>();
            //TimeSpan difference = (dtTo - dtFrom);
            //for (int i = 0; i <= difference.Days; i++)
            //{
            //    dateRange.Add(dtFrom.AddDays(i));
            //}

            //foreach (DateTime dateTime in dateRange)
            //{
            //    fillDb.FillHistory(dateTime);
            //}



            // 2. Пример конвертации
            ConvertCurrency cc = new ConvertCurrency();
            float convertingResult = cc.GetConvertResult(DateTime.Now, 100.0f, "HKD", "AMD");

            Console.WriteLine($@"Результат конвертации: {convertingResult}");
            Console.Read();
        }
    }
}