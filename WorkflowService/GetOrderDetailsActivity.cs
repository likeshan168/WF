using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using NorthwindDataModel;

namespace WorkflowService
{

    public sealed class GetOrderDetailsActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> orderID { get; set; }
        public OutArgument<List<Order_Detail>> OrderDetails { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            DbcontextDataContext dbContext = new DbcontextDataContext();
            context.SetValue(OrderDetails, (from detail in dbContext.Order_Details
                                            where detail.OrderID == context.GetValue(orderID)
                                            select detail).ToList());
        }
    }
}
