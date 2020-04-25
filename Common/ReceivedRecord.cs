using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common
{
    // TODO: name not clear. is this for the DB or for the Queue?
    public class ReceivedRecord
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

        public ReceivedRecord() { }

        // TODO: you are implementing the same business logic as the code you're testing
        // TODO: this is fundamentally wrong, since you are just comparing your own logic to the actual project.
        public ReceivedRecord(RecordToPublish record)
        {
            StoreId = record.StoreId;
            CreditCard = record.CreditCard;
            PurchaseDate = DateTime.Parse(record.PurchaseDate);
            TotalPrice = RoundDouble(record.TotalPrice);
            Installments = Convert.ToInt32(record.Installments is int ? record.Installments : 1);
            StoreType = StoreId[0];
            ActivityDays = StoreId[1];
            InsertionDate = record.InsertionDate;
            PricePerInstallment = RoundDouble(record.TotalPrice/Installments);
            IsValid = record.IsValid;
            WhyInvalid = record.WhyInvalid;
        }

        private double RoundDouble(double number)
        {
           return double.Parse(String.Format(ConfigorationValues.ExpectedPriceFormat, number));
        }

    }
}
