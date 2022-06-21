using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PUAProject.Models
{
    public partial class ShipAddress
    {
        public ShipAddress()
        {
            Orders = new HashSet<Order>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public string Street { get; set; } = null!;
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
