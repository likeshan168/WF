using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestOrders
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetOrders()
        {
            using (var ordering = new Ordering())
            {
                var custs = from cust in ordering.Customers
                            select cust;
                var customers = new Collection<Customer>();
                foreach (var c in custs)
                {
                    customers.Add(c);
                }
            }
        }

        [TestMethod]
        public void TestCodeFirst()
        {
            try
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Ordering>());

                using (var ordering = new Ordering())
                {
                    ordering.Database.Initialize(false);
                    var customer = new Customer
                    {
                        FirstName = "John",
                        LastName = "Smith"
                    };

                    var order = new Order
                    {
                        DateOrdered = DateTime.Now,
                        LineItems = new Collection<OrderLineItem>(),
                        ShippingState = "Florida"
                    };

                    order.LineItems.Add(new OrderLineItem()
                    {
                        LineDescription = "Widget 1",
                        Price = 5.50m,
                        SKU = "fff-321-gfsf"

                    });

                    order.LineItems.Add(new OrderLineItem()
                    {
                        LineDescription = "Widget 2",
                        Price = 4.10m,
                        SKU = "AAA-234-asdf"
                    });

                    order.LineItems.Add(new OrderLineItem()
                    {
                        LineDescription = "Widget 3",
                        Price = 10.10m,
                        SKU = "BBB-321-j7df"
                    });

                    customer.CustomerOrders.Add(order);
                    ordering.Entry(customer).State = EntityState.Added;
                    int result = ordering.SaveChanges();
                    Console.WriteLine(result);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
