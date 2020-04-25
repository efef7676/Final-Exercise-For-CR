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

        // TODO: instead of using an extension, you can overwrite RecordToPublish's toString
        public static string ConvertToString(this List<RecordToPublish> records)
        {
            // TODO: bad naming. Do not refer to a variable by its type
            // TODO: why var?
            var finalString = string.Empty;
            // TODO: why var?
            foreach (var record in records)
            {
                // TODO: why var?
                // TODO: what's so basic about it?
                var basicRecordInCSV = $"{record.StoreId},{record.CreditCard},{record.PurchaseDate},{record.TotalPrice}";

                // TODO: read about ternary conditional
                if (record.Installments != null)
                {
                    basicRecordInCSV += $",{record.Installments}" + Environment.NewLine;
                }
                else
                {
                    basicRecordInCSV += Environment.NewLine;
                }

                finalString += basicRecordInCSV;
            }
            return finalString;
        }

        public static List<ReceivedRecord> ConvertToReceivedRecords(this List<RecordToPublish> records)
        {
            // TODO: why var?
            var receivedRecords = new List<ReceivedRecord>();
            foreach (var recordToPublish in records)
            {
                receivedRecords.Add(new ReceivedRecord(recordToPublish));
            }

            return receivedRecords;
        }

    }
}
