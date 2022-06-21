//using PUAProject.Models;
//using PUAProject.Repository;
//using FluentValidation;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace PUAProject.Logic
//{
//    public class ProductLogic : IProductLogic
//    {
//        private readonly IPUAProjectRepository _repo;
//        private readonly IValidator<Product> _validator;

//        public ProductLogic(IPUAProjectRepository repo,
//            IValidator<Product> validator)
//        {
//            _repo = repo;
//            _validator = validator;
//        }

//        public async Task<List<Product>> GetAllProducts()
//        {
//            var products = await _repo.GetAllProductsAsync();

//            // converts products from DB to product models
//            return products.Select(Product.FromProduct).ToList();
//        }

//        public async Task<Product?> GetProductById(int id)
//        {
//            var product = await _repo.GetProductByIdAsync(id);
//            return product == null ? null : Product.FromProduct(product);
//        }

//        public async Task AddNewProduct(Product productToAdd)
//        {
//            await _validator.ValidateAndThrowAsync(productToAdd);
//            var productToSave = productToAdd.ToProduct();
//            await _repo.AddProductAsync(productToSave);
//        }

//        public async Task RemoveProduct(int id)
//        {
//            await _repo.RemoveProductAsync(id);
//        }

//        public async Task UpdateProduct(Product productToUpdate)
//        {
//            await _validator.ValidateAndThrowAsync(productToUpdate);
//            var productToSave = productToUpdate.ToProduct();
//            await _repo.UpdateProductAsync(productToSave);
//        }

//        public async Task<Product> InitializeProductModel()
//        {
//            return new Product
//            {
//                AvailableCategories = await GetAvailableCategoriesFromDb()
//            };
//        }

//        public async Task GetAvailableCategories(Product productModel)
//        {
//            productModel.AvailableCategories = await GetAvailableCategoriesFromDb();
//        }

//        private async Task<List<SelectListItem>> GetAvailableCategoriesFromDb()
//        {
//            var cats = await _repo.GetAllCategoriesAsync();
//            var returnList = new List<SelectListItem> { new("None", "") };
//            var availCatList = cats.Select(cat => new SelectListItem(cat.CategoryName, cat.Id.ToString())).ToList();
//            returnList.AddRange(availCatList);
//            return returnList;
//        }
//    }
//}