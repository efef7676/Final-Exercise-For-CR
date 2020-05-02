using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Common;
using System.Diagnostics;

namespace BL
{
    public class CommunicationWithDB
    {
        private ActionsInDB ActionsInDB { get; set; }
        public void OpenConnection() => ActionsInDB.OpenConnection();
        public void CloseConnection() => ActionsInDB.CloseConnection();

        public CommunicationWithDB()
        {
            ActionsInDB = new ActionsInDB();
        }

        public void DeleteFromDB()
        {
            ActionsInDB.ManipulationInDB.DeleteAllRows();
        }

        public List<ReceivedRecordFromDB> GetFromDB(string storeIdValue = "")
        {
            return ActionsInDB.RetrievalFromDB.GetRows(storeIdValue);
        }

        public void WaitUntilAmountOfRowsIsUpdate(int expectedNumberOfRows)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var isEqual = ActionsInDB.RetrievalFromDB.CountRows() == expectedNumberOfRows;
            while (!isEqual)
            {
                isEqual = ActionsInDB.RetrievalFromDB.CountRows() == expectedNumberOfRows;
                if (sw.ElapsedMilliseconds > 7000)
                    throw new TimeoutException();
            }
           
            return;
        }
    }
}
