using System.Collections.Generic;

namespace PUAProject.Models
{
    public class GetProductNamesModel
    {
       public List<ProductsNamesAndIds>ProductsNamesList { get; set; }

    }
    
    public class ProductsNamesAndIds
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
    }
}
