using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchanger.DataModel
{
    public class CurrencyInfo
    {
        [Key]
        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public string EngName { get; set; }
        public int Nominal { get; set; }
        public string ParentCode { get; set; }
        public int ISONumCode { get; set; }
        public string ISOCharCode { get; set; }
        public string ID { get; set; }
    }
}