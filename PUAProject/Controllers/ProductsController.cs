using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PUAProject.Helpers;
using PUAProject.Models;
using PUAProject.ViewModels;

namespace PUAProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PUA20832Context _context;

        public ProductsController(PUA20832Context context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(string searchString)
        {
            var articles = from m in _context.Products
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.ProductTitle!.Contains(searchString));
            }

            return View(await articles.ToListAsync());
        }

        public async Task<IActionResult> AddToCart(int Id)
        {
            CartContentModel productModel = new CartContentModel();
            if (SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart") == null)
            {
                List<CartContentModel> cart = new List<CartContentModel>();
                cart.Add(new CartContentModel { Id = Id, Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<CartContentModel> cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");
                int index = isExist(Id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartContentModel { Id = Id, Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Cart");
        }
        private int isExist(int id)
        {
            List<CartContentModel> cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }


        public async Task<IActionResult> Cart()

        {

            var cart = SessionHelper.GetObjectFromJson<List<CartContentModel>>(HttpContext.Session, "cart");

            ViewBag.cart = cart;

            var products = _context.Products

            .Where(x => cart.Select(p => p.Id)

            .Contains(x.Id))

            .ToList();


            var cartContent = new List<CartContentViewModel>();

            foreach (var product in products)

            {
                var quantity = cart.Where(c => c.Id == product.Id)

                .Select(c => c.Quantity).First();



                cartContent.Add(new CartContentViewModel()

                {

                    Id = product.Id,

                    ProductTitle = product.ProductTitle,

                    ImageUrl = product.ImageUrl,

                    Price = product.Price,

                    Quantity = quantity

                });

            }

            return View(cartContent);

        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return View("NotFound");
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return View("NotFound");
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductTitle,ProductContent,Price,CategoryId,CreatedDate,PublicationDate,LastModifiedDate,LastModifiedBy,IsActive,ImageUrl")] Product product)
        {
            //if (ModelState.IsValid)
            try
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["Id"] = new SelectList(_context.Categories, "Id", "CategoryName", product.CategoryId);
                return View(product);
            }
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return View("NotFound");
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return View("NotFound");
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductTitle,ProductContent,Price,CategoryId,CreatedDate,PublicationDate,LastModifiedDate,LastModifiedBy,IsActive,ImageUrl")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", product.CategoryId);
            //return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return View("NotFound");
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return View("NotFound");
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'PUA20832Context.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
