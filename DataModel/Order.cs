using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModel
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime DateOrdered { get; set; }
        [Required]
        public virtual ICollection<OrderLineItem> LineItems { get; set; }
    }
}
