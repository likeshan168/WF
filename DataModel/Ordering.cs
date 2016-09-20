using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public sealed class Ordering : DbContext
    {
        public Ordering() : base("server=.;database=test;uid=sa;pwd=sa;")
        { }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasMany(customer => customer.CustomerOrders);
            modelBuilder.Entity<Order>().HasMany(order => order.LineItems);

            modelBuilder.Entity<OrderLineItem>().HasKey(p => new { p.OrderId, p.LineItemId });
        }
    }
}
