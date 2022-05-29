using System;
using System.Collections.Generic;

namespace PUAProject.Models
{
    public partial class UserAddress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Number { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
