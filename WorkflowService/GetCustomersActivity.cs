using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using NorthwindDataModel;

namespace WorkflowService
{

    public sealed class GetCustomersActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public OutArgument<List<Customer>> Customers { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            DbcontextDataContext dbContext = new DbcontextDataContext();
            context.SetValue(Customers, dbContext.Customers.ToList());
        }
    }
}
