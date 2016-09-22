using System.Activities;
using DataModel;

namespace WFProject.Activities
{
    public class GetCustomerOrders : CodeActivity
    {
        [RequiredArgument]
        public OutArgument<Customers> outCustomers { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            using (var db = new Ordering())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var custs = db.Customers.Include("CustomerOrders.LineItems");

                var customers = new Customers();
                foreach (var c in custs)
                {
                    customers.Add(c);
                }

                context.SetValue(outCustomers, customers);

            }

        }
    }
}
