using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Common;
using System.Diagnostics;

namespace DAL
{
    public class ActionsInDB
    {
        private MySqlConnection Connection { get; set; }
        public ManipulationInDB ManipulationInDB { get; set; }
        public RetrievalFromDB RetrievalFromDB { get; set; }
        public void OpenConnection() => Connection.Open();
        public void CloseConnection() => Connection.Close();

        public ActionsInDB()
        {
            Connection = new MySqlConnection(ConfigorationsValues.ConnectionStringDB);
            ManipulationInDB = new ManipulationInDB(Connection);
            RetrievalFromDB = new RetrievalFromDB(Connection);
        }
    }
}
