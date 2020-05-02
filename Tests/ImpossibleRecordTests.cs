using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using Extensions;
using Assertions;
using System.Collections.Generic;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class ImpossibleRecordTests : BaseTest
    {
        private RecordToPublishToQueue _baseRecord;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _recordsToPublish.Add(new RecordToPublishToQueue());
            _baseRecord = new RecordToPublishToQueue();
        }

        [TestMethod]
        public void SendRecord_PurchaseDateInUnexpectedFormat_WillNotAddToDB()
        {
            //Arrange
            _baseRecord.SetPurchaseDateInUnexpectedFormat("yyyy.MM.dd");
            _recordsToPublish.Add(_baseRecord);

            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(1);

            //Assert
            _communicationWithDB.GetFromDB()
                .Should()
                .NotContainsStoreID(_baseRecord);
        }

        [TestMethod]
        public void SendRecord_ImpossiblePurchaseDate_WillNotAddToDB()
        {
            //Arrange
            _baseRecord.SetImpossiblePurchaseDate();
            _recordsToPublish.Add(_baseRecord);
            
            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(1);

            //Assert
            _communicationWithDB.GetFromDB()
                .Should()
                .NotContainsStoreID(_baseRecord);
        }

        [TestMethod]
        public void SendRecord_ImpossibleStoreId_WillNotAddToDB()
        {
            //Arrange
            _baseRecord.SetImpossibleStoreID();
            _recordsToPublish.Add(_baseRecord);

            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(1);

            //Assert
            _communicationWithDB.GetFromDB()
                .Should()
                .NotContainsStoreID(_baseRecord);
        }

        [TestMethod]
        public void SendRecord_ImpossiblePrice_WillNotAddToDB()
        {
            //Arrange
            _baseRecord.SetImpossibleTotalPrice();
            _recordsToPublish.Add(_baseRecord);

            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(1);

            //Assert
            _communicationWithDB.GetFromDB()
                 .Should()
                 .NotContainsStoreID(_baseRecord);
        }

        [TestMethod]
        public void SendRecord_ImpossibleInstallments_WillNotAddToDB()
        {
            //Arrange
            _baseRecord.SetImpossibleInstallments();
            _recordsToPublish.Add(_baseRecord);

            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(1);

            //Assert
            _communicationWithDB.GetFromDB()
                 .Should()
                 .NotContainsStoreID(_baseRecord);
        }
        
    }
}
