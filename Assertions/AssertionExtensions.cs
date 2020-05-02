using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assertions
{
    public static class AssertionExtensions 
    {
        public static ReceivedRecordsAssertions Should(this List<ReceivedRecordFromDB> instance) =>
            new ReceivedRecordsAssertions(instance);
    }
}
