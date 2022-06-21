using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PUAProject.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
