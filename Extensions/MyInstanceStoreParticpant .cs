using System;
using System.Activities.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Extensions
{
    public class MyInstanceStoreParticpant : PersistenceParticipant
    {
        public int TicketID { get; set; }
        XNamespace xns = XNamespace.Get("http://sherman.com/DocumentReview");

        protected override void CollectValues(out IDictionary<XName, object> readWriteValues, out IDictionary<XName, object> writeOnlyValues)
        {
            readWriteValues = new Dictionary<XName, object>();
            readWriteValues.Add(xns.GetName("TicketID"), this.TicketID);
            writeOnlyValues = null;
        }

    }
}
