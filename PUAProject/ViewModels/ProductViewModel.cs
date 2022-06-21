namespace PUAProject.ViewModelsCart
{
    public class ProductViewModel
    {
      
        public int Id { get; set; }
        public string ProductTitle { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;

    }
}
