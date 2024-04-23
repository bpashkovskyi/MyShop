using Microsoft.EntityFrameworkCore;

using MyShop.Domain.Models;
using MyShop.Persistence.Base;

namespace MyShop.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyShopContext context;

        public CategoryRepository(MyShopContext context)
        {
            this.context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await this.context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(Guid id)
        {
            return await this.context.Categories.FindAsync(id);
        }
    }
}
