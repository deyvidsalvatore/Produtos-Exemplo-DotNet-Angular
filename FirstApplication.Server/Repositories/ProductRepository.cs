using FirstApplication.Server.Data;
using FirstApplication.Server.Entities;
using FirstApplication.Server.Interfaces;
using FirstApplication.Server.Models;

namespace FirstApplication.Server.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<int> AddProduct(ProductModel productModel)
        {
            var product = new Product
            {
                Name = productModel.Name,
                Price = productModel.Price,
            };

            // Add the product to the database
            return await Add(product);
        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = await GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }

            // Remove the product from the database
            return await Remove(product);
        }

        public async Task<IEnumerable<Product>> GetList()
        {
            // Retrieve all products
            return await GetAll();
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }

            return product;
        }

        public async Task<int> UpdateProduct(ProductModel productModel)
        {
            var product = await GetById(productModel.Id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }

            product.Name = productModel.Name;
            product.Price = productModel.Price;

            // Update the product in the database
            return await Update(product);
        }
    }
}
