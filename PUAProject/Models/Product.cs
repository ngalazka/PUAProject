using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PUAProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;



namespace PUAProject.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Title")]
        public string ProductTitle { get; set; } = null!;
        [Display(Name = "Product Content")]
        public string ProductContent { get; set; } = null!;
        [DataType(DataType.Currency)]
        [Range(0.01, 100.00, ErrorMessage = "Value for {0} must be between" + "{1:C} and {2:C}")]
        public decimal Price { get; set; }
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; set; }
        [Display(Name = "Last Modified Date")]
        public DateTime LastModifiedDate { get; set; }
        [Display(Name = "Last Modified By")]
        public string LastModifiedBy { get; set; } = null!;
        [Display(Name = "Is Active")]
        public bool? IsActive { get; set; }
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        //public List<SelectListItem> AvailableCategories { get; set; } = new();

        //public static Product FromProduct(Product product)
        //{
        //    return new Product
        //    {
        //        Id = product.Id,
        //        ProductTitle = product.ProductTitle,
        //        ProductContent = product.ProductContent,
        //        Price = product.Price,
        //        CategoryId = product.CategoryId,
        //        CreatedDate = product.CreatedDate,
        //        PublicationDate = product.PublicationDate,
        //        LastModifiedDate = product.LastModifiedDate,
        //        LastModifiedBy = product.LastModifiedBy,
        //        IsActive = product.IsActive,
        //        ImageUrl = product.ImageUrl,
        //    };
        //}

        //public Product ToProduct()
        //{
        //    return new Product
        //    {
        //        Id = Id,
        //        ProductTitle = ProductTitle,
        //        ProductContent = ProductContent,
        //        Price = Price,
        //        CategoryId = CategoryId,
        //        CreatedDate = CreatedDate,
        //        PublicationDate = PublicationDate,
        //        LastModifiedDate = LastModifiedDate,
        //        LastModifiedBy = LastModifiedBy,
        //        IsActive = IsActive,
        //        ImageUrl = ImageUrl,
        //    };

        //}
    }


   
}
