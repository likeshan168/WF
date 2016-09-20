using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel
{
    public class OrderLineItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LineItemId { get; set; }
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string LineDescription { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public Decimal? Price { get; set; }
    }
}
