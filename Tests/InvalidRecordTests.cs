using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System.Collections.Generic;
using Extensions;
using Assertions;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class InvalidRecordTests : BaseTest
    {
        private RecordToPublishToQueue _baseRecord;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _baseRecord = new RecordToPublishToQueue();
        }

        [TestMethod]
        public void SendRecord_InvalidCreditCard_AddedsuccessfullyToDBAsInvalid()
        {
            //Arrange
            _baseRecord.SetInvalidCreditCard();
            _recordsToPublish.Add(_baseRecord);

            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(_recordsToPublish.Count);

            //Assert
            _communicationWithDB.GetFromDB()
                .Should()
                .BeAddedSuccessfully(_recordsToPublish);
        }//Dont run this test!! - this may chrush the code

        [TestMethod]
        public void SendRecord_InvalidInstallments_AddedsuccessfullyToDBAsInvalid()
        {
            //Arrange
            _baseRecord.SetInvalidInstallments();
            _recordsToPublish.Add(_baseRecord);

            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(_recordsToPublish.Count);

            //Assert
            _communicationWithDB.GetFromDB()
                .Should()
                .BeAddedSuccessfully(_recordsToPublish);
        }

        [TestMethod]
        public void SendRecord_PurchaseDateIsWhenStoreIsClose_AddedsuccessfullyToDBAsInvalid()
        {
            //Arrange
            _baseRecord.SetActivityDays('C');
            _baseRecord.SetPurchaseDateInSaturday();
            _recordsToPublish.Add(_baseRecord);

            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(_recordsToPublish.Count);

            //Assert
            _communicationWithDB.GetFromDB()
                .Should()
                .BeAddedSuccessfully(_recordsToPublish);
        }

        [TestMethod]
        public void SendRecord_PurchaseDateIsLaterThanTheCurrentDate_AddedsuccessfullyToDBAsInvalid()
        {
            //Arrange
            _baseRecord.SetPurchaseDateLaterThanCurrentDate();
            _recordsToPublish.Add(_baseRecord);

            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(_recordsToPublish.Count);

            //Assert
            _communicationWithDB.GetFromDB()
                .Should()
                .BeAddedSuccessfully(_recordsToPublish);
        }

        [TestMethod]
        public void SendRecord_InvalidPricePerInstallment_AddedsuccessfullyToDBAsInvalid()
        {
            //Arrange
            _baseRecord.SetInvalidPricePerInstallment();
            _recordsToPublish.Add(_baseRecord);

            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(_recordsToPublish.Count);

            //Assert
            _communicationWithDB.GetFromDB()
                .Should()
                .BeAddedSuccessfully(_recordsToPublish);
        }
    }
}
