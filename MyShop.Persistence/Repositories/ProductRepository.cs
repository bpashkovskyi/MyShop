using Microsoft.EntityFrameworkCore;

using MyShop.Domain.Models;
using MyShop.Persistence.Base;

namespace MyShop.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly MyShopContext context;

    public ProductRepository(MyShopContext context)
    {
        this.context = context;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await this.context.Products.ToListAsync();
    }
        
    public async Task<Product> GetProduct(Guid id)
    {
        return await this.context.Products.FindAsync(id);
    }
}