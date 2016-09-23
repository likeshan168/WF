using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using NorthwindDataModel;

namespace WorkflowService
{

    public sealed class GetOrdersActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> customerID { get; set; }
        public OutArgument<List<Order>> Orders { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            DbcontextDataContext dbContext = new DbcontextDataContext();
            context.SetValue(Orders, (from order in dbContext.Orders
                                     where order.CustomerID == context.GetValue(customerID)
                                     select order).ToList());
        }
    }
}
