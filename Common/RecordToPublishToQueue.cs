using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class RecordToPublishToQueue
    {
        private static Random _random = new Random();
        public GeneratorForRecords Generator = new GeneratorForRecords();
        public string StoreId { get; set; }
        public string CreditCard { get; set; }
        public dynamic PurchaseDate { get; set; }
        public dynamic TotalPrice { get; set; }
        public dynamic Installments { get; set; }
        public DateTime InsertionDate { get; set; }
        public bool IsValid { get; set; }
        public string WhyInvalid { get; set; }

        public RecordToPublishToQueue()
        {
            StoreId = Generator.GenerateValidStoreId();
            CreditCard = "4557446145890236";
            PurchaseDate = Generator.GenerateValidDate(StoreId[1]).ToString(ConfigorationsValues.ExpectedDateFormat);
            TotalPrice = Generator.GenerateIntegerPrice(true);
            Installments = Generator.GenerateInstallmentsByPrice(true, TotalPrice);
            IsValid = true;
            WhyInvalid = null;
            InsertionDate = DateTime.Now.Date;
        }

        public void SetMoreThanOneInstallments()
        {
            TotalPrice = Generator.GenerateIntegerPrice(false);
            Installments = Generator.GenerateInstallmentsByPrice(false, TotalPrice);
        }

        public override string ToString()
        {
            var record = $"{StoreId},{CreditCard},{PurchaseDate},{TotalPrice}";

            if (Installments != null)
            {
                record += $",{Installments}" + Environment.NewLine;
            }
            else
            {
                record += Environment.NewLine;
            }

            return record;
        }

        public RecordToPublishToQueue SetAsImpossibleRecord()
        {
            StoreId = $"{_random.Next()}";
            PurchaseDate = Generator.GenerateValidDate();
            TotalPrice = Generator.GenerateValidStoreId();
            Installments = _random.Next(-100, 0);

            return this;
        }

        public void SetActivityDays(char activityDays = ' ')
        {
            var storeId = new StringBuilder(StoreId);
            storeId[1] = activityDays;
            StoreId = Convert.ToString(storeId);
        }

        public static List<RecordToPublishToQueue> CreateNValidRecordsToPublish(int numberOfRecords)
        {
            var records = new List<RecordToPublishToQueue>();
            for (int i = 0; i < numberOfRecords; i++)
            {
                records.Add(new RecordToPublishToQueue());
            }

            return records;
        }
    }
}
