using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PUAProject.Models;

namespace PUAProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsAPIController : ControllerBase
    {
        private readonly PUA20832Context _context;

        public ProductsAPIController(PUA20832Context context)
        {
            _context = context;
        }

        // GET: api/ProductsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            return await _context.Products.ToListAsync();
        }

        // GET: api/ProductsNamesAPI
        [HttpGet("GetProductsNames/")]
        public async Task<ActionResult<GetProductNamesModel>> GetProductNames()
        {
            var products = await _context.Products.ToListAsync();
            var model = new GetProductNamesModel { ProductsNamesList = new List<ProductsNamesAndIds>()};
            foreach (var product in products)
            {
                model.ProductsNamesList.Add(new ProductsNamesAndIds { Id = product.Id, ProductTitle = product.ProductTitle});
            }
            return model;
        }



        // GET: api/ProductsByIdAPI
        [HttpGet("FilterProductsById/{Id}")]
        public async Task<ActionResult<FilterProductsByIdModel>> FilterProductsById(int Id)
        {
            var product = await _context.Products.FindAsync(Id);

            if (_context.Products == null)
            {
                return NotFound();
            }
            var model = new FilterProductsByIdModel() { Id = product.Id, ProductName = product.ProductTitle, Price = product.Price};
            return model;
        }



        // GET: api/ProductsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          if (_context.Products == null)
          {
              return NotFound();
          }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/ProductsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
          if (_context.Products == null)
          {
              return Problem("Entity set 'PUA20832Context.Products'  is null.");
          }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/ProductsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
