using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PUAProject.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        [Display(Name = "Address Id")]
        public int AddressId { get; set; }
        public string Role { get; set; } = null!;
        [Display(Name = "Is Active")]
        public bool? IsActive { get; set; }
        [Display(Name = "Created Date ")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; } = null!;
        [Display(Name = "Last Modified Date")]
        public DateTime LastModifiedDate { get; set; }
        [Display(Name = "Last Modified By ")]
        public string LastModifiedBy { get; set; } = null!;

        public virtual ShipAddress Address { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
