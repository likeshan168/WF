using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFHost
{
    public class CommonService : ICommonService
    {
        public int[] GetTicketIDs()
        {
            var ctx = new InstanceStoreDataContext();
            return ctx.DocumentReviewTasks.Select(r => (int)r.TicketId).ToArray();
        }
    }
}
