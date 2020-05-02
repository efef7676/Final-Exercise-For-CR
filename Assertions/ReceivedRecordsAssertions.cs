using FluentAssertions;
using FluentAssertions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Extensions;

namespace Assertions
{
    public class ReceivedRecordsAssertions : ObjectAssertions
    {
        private List<ReceivedRecordFromDB> ReceivedRecords => Subject as List<ReceivedRecordFromDB>;
        protected override string Identifier => "ReceivedRecordsAssertions";

        public ReceivedRecordsAssertions(List<ReceivedRecordFromDB> value) : base(value)
        {
        }


        [CustomAssertion]
        public AndConstraint<ReceivedRecordsAssertions> BeAddedSuccessfully(List<RecordToPublishToQueue> sentRecords)
        {
            ReceivedRecords
                .AreSameRecords(sentRecords)
                .Should()
                .BeTrue();

            return new AndConstraint<ReceivedRecordsAssertions>(this);
        }

        [CustomAssertion]
        public AndConstraint<ReceivedRecordsAssertions> NotContainsStoreID(RecordToPublishToQueue sentRecord)
        {
            ReceivedRecords.FirstOrDefault(record => record.StoreId == sentRecord.StoreId)
                .Should()
                .BeNull();

            return new AndConstraint<ReceivedRecordsAssertions>(this);
        }
    }
}
