using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class RetrievalFromDB
    {
        private MySqlConnection Connection { get; set; }

        public RetrievalFromDB(MySqlConnection connection)
        {
            Connection = connection;
        }

        public List<ReceivedRecordFromDB> GetRows(string storeIdValue = "")
        {
            string query;
            var receivedRecords = new List<ReceivedRecordFromDB>();

            if (String.IsNullOrEmpty(storeIdValue))
            {
                query = "SELECT * FROM purchases";
            }
            else
            {
                query = $"SELECT * FROM purchases WHERE store_id='{storeIdValue}'";
            }

            var dataReader = new MySqlCommand(query, Connection).ExecuteReader();

            while (dataReader.Read())
            {
                receivedRecords.Add(ParseRows(dataReader));
            }

            return receivedRecords;
        }

        private ReceivedRecordFromDB ParseRows(MySqlDataReader dataReader)
        {
            var receivedRecord = new ReceivedRecordFromDB();

            receivedRecord.StoreId = dataReader[ConfigorationsValues.StoreIdField].ToString();
            receivedRecord.StoreType = char.Parse(dataReader[ConfigorationsValues.StoreTypeField].ToString());
            receivedRecord.ActivityDays = char.Parse(dataReader[ConfigorationsValues.ActivityDaysField].ToString());
            receivedRecord.CreditCard = dataReader[ConfigorationsValues.CreditCardField].ToString();
            receivedRecord.PurchaseDate = DateTime.Parse(dataReader[ConfigorationsValues.PurchaseDateField].ToString());
            receivedRecord.InsertionDate = DateTime.Parse(dataReader[ConfigorationsValues.InsertionDateField].ToString());
            receivedRecord.TotalPrice = double.Parse(dataReader[ConfigorationsValues.TotalPriceField].ToString());
            receivedRecord.Installments = int.Parse(dataReader[ConfigorationsValues.InstallmentsField].ToString());
            receivedRecord.PricePerInstallment = double.Parse(dataReader[ConfigorationsValues.PricePerInstallmentField].ToString());
            receivedRecord.IsValid = dataReader[ConfigorationsValues.IsValidField].ToString() == "1" ? true : false;
            receivedRecord.WhyInvalid = dataReader[ConfigorationsValues.WhyInvalidField].ToString();

            return receivedRecord;
        }

        public int CountRows()
        {
            string query = "SELECT COUNT(*) FROM purchases";
            var receivedRecords = new List<ReceivedRecordFromDB>();
            var cmd = new MySqlCommand(query, Connection);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

}
