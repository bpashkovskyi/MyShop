using Microsoft.EntityFrameworkCore;

using MyShop.Domain.Models;
using MyShop.Persistence.Base;

namespace MyShop.Persistence.Repositories;

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

    public async Task<Category> GetCategory(string name)
    {
        return await this.context.Categories.FirstOrDefaultAsync(category => category.Name == name);
    }

    public async Task<Category> AddCategory(Category category)
    {
        await this.context.Categories.AddAsync(category);
        await this.context.SaveChangesAsync();

        return category;
    }

    public async Task<Category> UpdateCategory(Category category)
    {
        this.context.Categories.Update(category);
        await this.context.SaveChangesAsync();

        return category;
    }

    public async Task DeleteCategory(Category category)
    {
        this.context.Remove(category);
        await this.context.SaveChangesAsync();
    }
}