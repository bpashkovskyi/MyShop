using MyShop.Domain.Models;

namespace MyShop.Persistence.Base;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllCategories();
    Task<Category> GetCategory(Guid id);
    Task<Category> GetCategory(string name);
}