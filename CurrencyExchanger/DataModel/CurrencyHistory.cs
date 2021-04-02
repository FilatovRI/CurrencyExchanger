using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchanger.DataModel
{
    public class CurrencyHistory
    {
        [Key]
        public int HistoryId { get; set; }
        public CurrencyInfo Currency { get; set; }
        public DateTime Date { get; set; }
        public float Value { get; set; }
        public int Nominal { get; set; }
    }
}