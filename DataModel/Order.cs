using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public decimal Tax { get; set; }
        [NotMapped]
        public decimal TotalPrice { get; set; }
        [NotMapped]
        public bool OrderApproved { get; set; }
        [Required]
        public string ShippingState { get; set; }
        [Required]
        public virtual ICollection<OrderLineItem> LineItems { get; set; }
    }
}
