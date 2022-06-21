using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PUAProject.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Last Modified Date")]
        public DateTime LastModifiedDate { get; set; }
        [Display(Name = "Last Modified By")]
        public string LastModifiedBy { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
