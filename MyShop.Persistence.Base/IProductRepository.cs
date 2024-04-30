using MyShop.Domain.Models;

namespace MyShop.Persistence.Base;

public interface IProductRepository
{
    Task<List<Product>> GetAllProducts();
    Task<Product> GetProduct(Guid id);
}