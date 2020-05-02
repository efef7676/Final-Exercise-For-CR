using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class ImpossibleRecordExtensions
    {
        private static Random _random = new Random();

        public static void SetImpossibleStoreID(this RecordToPublishToQueue record)
        {
            var options = new string[] { $"{_random.Next()}", String.Empty };
            record.StoreId = options[_random.Next(options.Length)];
        }
        public static void SetPurchaseDateInUnexpectedFormat(this RecordToPublishToQueue record, string invalidFormat) =>
            record.PurchaseDate = record.Generator.GenerateValidDate().ToString(invalidFormat);

        public static void SetImpossiblePurchaseDate(this RecordToPublishToQueue record)
        {
            var impossibleDate =$"2005-{_random.Next(13, 25)}-{_random.Next(33, 45)}"; 
            var options = new dynamic[] {record.Generator.GenerateValidStoreId(), _random.Next(), impossibleDate, String.Empty};
            record.PurchaseDate = options[_random.Next(options.Length)];
        }
        public static void SetImpossibleTotalPrice(this RecordToPublishToQueue record)
        {
            var options = new dynamic[] { _random.Next(-100, -1), record.Generator.GenerateValidStoreId(), String.Empty};
            record.TotalPrice = options[_random.Next(options.Length)];
        }
        
        public static void SetImpossibleInstallments(this RecordToPublishToQueue record)
        {
            var optionsToInvalidInstallments = new dynamic[] { _random.Next(-100, -1), "full", "abcdss" };
            record.Installments = optionsToInvalidInstallments[_random.Next(optionsToInvalidInstallments.Length)];
        }
    }
}
