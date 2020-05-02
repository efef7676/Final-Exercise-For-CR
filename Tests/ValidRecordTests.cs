using System;
using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Extensions;
using Common;
using System.Collections.Generic;
using FluentAssertions;
using System.Threading;
using Assertions;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class ValidRecordTests : BaseTest
    {
        [TestMethod]
        public void SendOneValidRecordToFullDB_MoreThanOneInstallment_AddedSuccessfullyToDBAsValid()
        {
            //Arrange
            _rabbitMq.PublishMessage(new List<RecordToPublishToQueue>() { new RecordToPublishToQueue() }.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(1);

            var recordToPublish = new RecordToPublishToQueue();
            recordToPublish.SetMoreThanOneInstallments();
            _recordsToPublish.Add(recordToPublish);

            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(_recordsToPublish.Count + 1);

            //Assert
            _communicationWithDB.GetFromDB(_recordsToPublish[0].StoreId)
                .Should()
                .BeAddedSuccessfully(_recordsToPublish);
        }

        [TestMethod]
        public void SendOneValidRecordToFullDB_OneInstallment_AddedSuccessfullyToDBAsValid()
        {
            //Arrange
            _rabbitMq.PublishMessage(new List<RecordToPublishToQueue>() { new RecordToPublishToQueue() }.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(1);

            _recordsToPublish.Add(new RecordToPublishToQueue());
            
            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(_recordsToPublish.Count + 1);

            //Assert
            _communicationWithDB.GetFromDB(_recordsToPublish[0].StoreId)
                .Should()
                .BeAddedSuccessfully(_recordsToPublish);
        }

        [TestMethod]
        public void SendFewValidRecords_AddedSuccessfullyToDBAsValid()
        {
            //Arrange
            _recordsToPublish.AddRange(RecordToPublishToQueue.CreateNValidRecordsToPublish(20));

            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(_recordsToPublish.Count);

            //Assert
            _communicationWithDB.GetFromDB()
                .Should()
                .BeAddedSuccessfully(_recordsToPublish);
        }

        [TestMethod]
        public void SendSameValidRecords_AddedSuccessfullyToDBAsValid()
        {
            //Arrange
            var recordToPublish = new RecordToPublishToQueue();
            _recordsToPublish.AddMany(recordToPublish, recordToPublish);

            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(_recordsToPublish.Count);

            //Assert
            _communicationWithDB.GetFromDB()
                .Should()
                .BeAddedSuccessfully(_recordsToPublish);
        }

        [TestMethod]
        public void ValidRecordAndImpossibleRecord_ValidRecordAddedSuccessfullyToDB()
        {
            //Arrange
            var validRecord = new RecordToPublishToQueue();
            var impossibleRecord = new RecordToPublishToQueue().SetAsImpossibleRecord();
            _recordsToPublish.AddMany(impossibleRecord, validRecord);

            //Act
            _rabbitMq.PublishMessage(_recordsToPublish.ConvertToString());
            _communicationWithDB.WaitUntilAmountOfRowsIsUpdate(1);

            //Assert
            _communicationWithDB.GetFromDB()
                .Should()
                .BeAddedSuccessfully(new List<RecordToPublishToQueue>() { validRecord });
        }
    }
}
