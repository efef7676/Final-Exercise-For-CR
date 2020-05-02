using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Extensions
{
    public static class GeneralRecordExtensions
    {
        public static string ConvertToString(this List<RecordToPublishToQueue> records)
        {
            var allRecords = string.Empty;

            foreach (var record in records)
            {
                allRecords += record.ToString();
            }
            return allRecords;
        }

        //public static List<ReceivedRecordFromDB> ConvertToReceivedRecords(this List<RecordToPublishToQueue> records)
        //{
        //    var receivedRecords = new List<ReceivedRecordFromDB>();
        //    foreach (var recordToPublish in records)
        //    {
        //        receivedRecords.Add(new ReceivedRecordFromDB(recordToPublish));
        //    }

        //    return receivedRecords;


        public static bool AreSameRecords(this List<ReceivedRecordFromDB> recordsFromDB, List<RecordToPublishToQueue> recordsToQueue)
        {
            //bool areSame;
            for (int i = 0; i < recordsFromDB.Count; i++)
            {
                var expectedTotalPrice = double.Parse(String.Format(ConfigorationsValues.ExpectedPriceFormat, recordsToQueue[i].TotalPrice));
                var installments = Convert.ToInt32(recordsToQueue[i].Installments is int ? recordsToQueue[i].Installments : 1);

                if (recordsFromDB[i].StoreId != recordsToQueue[i].StoreId ||
                    recordsFromDB[i].CreditCard != recordsToQueue[i].CreditCard ||
                    recordsFromDB[i].PurchaseDate != DateTime.Parse(recordsToQueue[i].PurchaseDate) ||
                    recordsFromDB[i].TotalPrice != expectedTotalPrice ||
                    recordsFromDB[i].Installments != Convert.ToInt32(recordsToQueue[i].Installments is int ? recordsToQueue[i].Installments : 1) ||
                    recordsFromDB[i].StoreType != recordsToQueue[i].StoreId[0] ||
                    recordsFromDB[i].ActivityDays != recordsToQueue[i].StoreId[1] ||
                    recordsFromDB[i].PricePerInstallment != double.Parse(String.Format(ConfigorationsValues.ExpectedPriceFormat, expectedTotalPrice/installments)) ||
                    recordsFromDB[i].InsertionDate != recordsToQueue[i].InsertionDate ||
                    recordsFromDB[i].IsValid != recordsToQueue[i].IsValid ||
                    recordsFromDB[i].WhyInvalid != recordsToQueue[i].WhyInvalid)
                {
                    return false;
                }
            }

            return true;
        }
           
    }
}
