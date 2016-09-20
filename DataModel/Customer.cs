using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public class Customer
    {
        public Customer()
        {
            CustomerOrders = new Collection<Order>();
        }

        [Key]
        public int CustomerId { get; set; }
        public string CCNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual ICollection<Order> CustomerOrders { get; set; }

    }

    public class Customers : Collection<Customer>
    {

    }

}
