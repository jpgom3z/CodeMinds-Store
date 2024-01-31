using API.Data.Filters;
using API.Data.Models;

namespace API.Services
{
    public interface ICategoryService
    {
        IQueryable<Category> ListCategories(CategoryListFilter? filter = null);
        Task<Category?> FindCategory(int id);
        Task InsertCategory(Category entity);
        Task UpdateCategory(Category entity);
        //Task DisableCategory(Category entity);
        //Task EnableCategory(Category entity);
    }
}
