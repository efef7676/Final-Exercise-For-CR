using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common
{
    public class ReceivedRecordFromDB
    {
        public string StoreId { get; set; }
        public string CreditCard { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double TotalPrice { get; set; }
        public int Installments { get; set; }
        public char StoreType { get; set; }
        public char ActivityDays { get; set; }
        public DateTime InsertionDate { get; set; }
        public double PricePerInstallment { get; set; }
        public bool IsValid { get; set; }
        public string WhyInvalid { get; set; }

        public ReceivedRecordFromDB() { }

    }
}
