using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Extensions
{

    public sealed class SetTicket : CodeActivity
    {
        public InArgument<int> TicketID { get; set; }

       
        protected override void Execute(CodeActivityContext context)
        {
            var extension = context.GetExtension<MyInstanceStoreParticpant>();

            extension.TicketID = context.GetValue(TicketID);
        }
    }
}
