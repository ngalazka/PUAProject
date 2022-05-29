using System;
using System.Collections.Generic;

namespace PUAProject.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string ProductTitle { get; set; } = null!;
        public string ProductContent { get; set; } = null!;
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; } = null!;
        public bool? IsActive { get; set; }
        public string Size { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
