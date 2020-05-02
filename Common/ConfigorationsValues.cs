using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Common
{
    public static class ConfigorationsValues
    {
        public static string ConnectionStringDB = ConfigurationManager.AppSettings["CONNECTION_STRING_DB"];
        public static string QueueName = ConfigurationManager.AppSettings["QUEUE_NAME"];

        public static string ExpectedDateFormat = ConfigurationManager.AppSettings["EXPECTED_DATE_FORMAT"];
        public static string ExpectedPriceFormat = ConfigurationManager.AppSettings["EXPECTED_PRICE_FORMAT"];
        public static string StoreIdFormat = ConfigurationManager.AppSettings["STORE_ID_FORMAT"];

        
        public static string CreditCardError = ConfigurationManager.AppSettings["CREDIT_CARD_ERROR"];
        public static string InstallmentsError = ConfigurationManager.AppSettings["INSTALLMENTS_ERROR"];
        public static string PurchaseDateWhenStoreIsCloseError = ConfigurationManager.AppSettings["PURCHASE_DATE_CLOSE_STORE_ERROR"];
        public static string PricePerInstallmentError = ConfigurationManager.AppSettings["PRICE_PER_INSTALLMENT_ERROR"];
        public static string PurchaseDateLaterThanCurrentDateError = ConfigurationManager.AppSettings["PURCHASE_DATE_LATER_THAN_NOW_ERROR"];


        public static string StoreIdField = ConfigurationManager.AppSettings["STORE_ID_FIELD"];
        public static string ActivityDaysField = ConfigurationManager.AppSettings["ACTIVITY_DAYS_FIELD"];
        public static string StoreTypeField = ConfigurationManager.AppSettings["STORE_TYPE_FIELD"];
        public static string CreditCardField = ConfigurationManager.AppSettings["CREDIT_CARD_FIELD"];
        public static string PurchaseDateField = ConfigurationManager.AppSettings["PURCHASE_DATE_FIELD"];
        public static string TotalPriceField = ConfigurationManager.AppSettings["TOTAL_PRICE_FIELD"];
        public static string InsertionDateField = ConfigurationManager.AppSettings["INSERTION_DATE_FIELD"];
        public static string InstallmentsField = ConfigurationManager.AppSettings["INSTALLMENTS_FIELD"];
        public static string PricePerInstallmentField = ConfigurationManager.AppSettings["PRICE_PER_INSTALLMENT_FIELD"];
        public static string IsValidField = ConfigurationManager.AppSettings["IS_VALID_FIELD"];
        public static string WhyInvalidField = ConfigurationManager.AppSettings["WHY_INVALID_FIELD"];

        
    }
}
