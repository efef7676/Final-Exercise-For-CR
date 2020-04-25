using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Common;

namespace DAL
{
    // TODO: this should have been in the BL. you are not accessing the DB directly here.
    public class ActionsInDB
    {
        private MySqlConnection Connection { get; set; }
        public ManipulationInDB ManipulationInDB { get; set; }
        public RetrievalFromDB RetrievalFromDB { get; set; }
        public void OpenConnection() => Connection.Open();
        public void CloseConnection() => Connection.Close();

        public ActionsInDB()
        {
            Connection = new MySqlConnection(ConfigorationValues.ConnectionStringDB);
            ManipulationInDB = new ManipulationInDB(Connection);
            RetrievalFromDB = new RetrievalFromDB(Connection);
        }

        // TODO: this should not be in DAL. the DAL should contain only basic actions
        public void WaitUntilAmountOfRowsIsUpdate(int expectedNumberOfRows)
        {
            // TODO: why var?
            var isAmountOfRowsEqual = RetrievalFromDB.IsDBHavaNRecords(expectedNumberOfRows);
            // TODO: no timeout? this can be endless if there's a bug 
            while (!isAmountOfRowsEqual)
            {
                isAmountOfRowsEqual = RetrievalFromDB.IsDBHavaNRecords(expectedNumberOfRows);
            }
            return;


            // TODO: why code in comment?
            //while (!RetrievalFromDB.IsDBHavaNRecords(expectedNumberOfRows))
            //{
            //    continue;
            //}
            //return;
        }
    }
}
