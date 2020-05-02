using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class InvalidRecordExtensions
    {
        private static Random _random = new Random();

        public static void SetInvalidCreditCard(this RecordToPublishToQueue record)
        {
            var invalidOptions = new string[] {String.Join( "-", record.CreditCard), record.Generator.GenerateValidStoreId(), $"{_random.Next(1000, 99999)}", String.Empty};
            record.CreditCard = invalidOptions[_random.Next(invalidOptions.Length)];
            record.WhyInvalid = ConfigorationsValues.CreditCardError;
            record.IsValid = false;
        }

        public static void SetPurchaseDateLaterThanCurrentDate(this RecordToPublishToQueue record)
        {
            var start = DateTime.Now.AddMonths(2);
            var end = DateTime.Now.AddMonths(5);
            var range = (end - start).Days;
            record.PurchaseDate = start.AddDays(_random.Next(range)).ConvertByExpectedDateFormat();
            record.IsValid = false;
            record.WhyInvalid = ConfigorationsValues.PurchaseDateLaterThanCurrentDateError;
        }

        public static void SetPurchaseDateInSaturday(this RecordToPublishToQueue record)
        {
            var start = new DateTime(2000, 1, 1);
            var range = (DateTime.Today - start).Days;
            var date = start.AddDays(_random.Next(range));
            while ((int)date.DayOfWeek != 6)
            {
                date = start.AddDays(_random.Next(range));
            }

            record.PurchaseDate = date.ConvertByExpectedDateFormat();
            record.IsValid = false;
            record.WhyInvalid = ConfigorationsValues.PurchaseDateWhenStoreIsCloseError;
        }

        public static void SetInvalidPricePerInstallment(this RecordToPublishToQueue record)
        {
            record.TotalPrice = _random.Next(5001, 10000);
            record.Installments = 1;
            record.IsValid = false;
            record.WhyInvalid = ConfigorationsValues.PricePerInstallmentError;
        }

        public static void SetInvalidInstallments(this RecordToPublishToQueue record)
        {
            record.TotalPrice = 5000;
                //_random.Next(5000);
            record.Installments = _random.Next(record.TotalPrice * 10 + 1, int.MaxValue);
            record.IsValid = false;
            record.WhyInvalid = ConfigorationsValues.InstallmentsError;
        }

    }
}
