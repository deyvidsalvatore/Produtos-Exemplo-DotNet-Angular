using FirstApplication.Server.Entities;
using FirstApplication.Server.Models;

namespace FirstApplication.Server.Interfaces
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetList();
        Task<Product> GetProduct(int id);
        Task<int> AddProduct(ProductModel productModel);
        Task<int> UpdateProduct(ProductModel productModel);
        Task<int> DeleteProduct(int id);
    }
}
