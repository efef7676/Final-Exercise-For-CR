using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using System.Collections.Generic;
using Common;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class BaseTest
    {
        private Process _process;
        protected CommunicationWithDB _communicationWithDB;
        protected CommunicationWithRabbitMQ _rabbitMq;
        protected List<RecordToPublishToQueue> _recordsToPublish;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                WorkingDirectory = @"C:\JAR",
                Arguments = "/c java -jar PurchasesPipeline_1.0.1.jar"
            };

            _process = new Process { StartInfo = startInfo };
            _process.Start();

            _communicationWithDB = new CommunicationWithDB();
            _rabbitMq = new CommunicationWithRabbitMQ();
            _recordsToPublish = new List<RecordToPublishToQueue>();

            _communicationWithDB.OpenConnection();
            _communicationWithDB.DeleteFromDB();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            _communicationWithDB.CloseConnection();
            _process.CloseMainWindow();
        }
    }
}
