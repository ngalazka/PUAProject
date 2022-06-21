namespace PUAProject.ViewModels
{
    public class CartContentViewModel
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
