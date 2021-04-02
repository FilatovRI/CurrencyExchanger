using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchanger.DataModel
{
    public class CurrencyList
    {
        public int Id { get; set; }
        public CurrencyInfo[] Currency { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}