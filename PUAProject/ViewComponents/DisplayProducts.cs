
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PUAProject.Models;
using PUAProject.ViewModelsCart;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUAProject.ViewComponents
{
    public class DisplayProducts : ViewComponent
    {

        private readonly PUA20832Context _context;

        public DisplayProducts(PUA20832Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _context.Products.ToListAsync();

            //if (order == null)
            //{
            //    return NotFound();
            //}
            var productsviewmodel = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsviewmodel.Add(new ProductViewModel {Id = product.Id, ProductTitle = product.ProductTitle, Price = product.Price, ImageUrl = product.ImageUrl });
            }
            return View(productsviewmodel);

        }
    }
}