using System;
using System.Collections.Generic;

namespace PUAProject.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OrderStatus { get; set; } = null!;
        public string PaymentMethod { get; set; } = null!;
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }

        public virtual ShipAddress Address { get; set; } = null!;
        public virtual User Customer { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
