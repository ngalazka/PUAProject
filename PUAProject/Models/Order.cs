using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PUAProject.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }
        [Display(Name = "Order Status")]
        public string OrderStatus { get; set; } = null!;
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; } = null!;
        [Display(Name = "Address Id")]
        public int AddressId { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Required Date")]
        public DateTime RequiredDate { get; set; }
        [Display(Name = "Shipped Date")]
        public DateTime ShippedDate { get; set; }

        public virtual ShipAddress Address { get; set; } = null!;
        public virtual User Customer { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
