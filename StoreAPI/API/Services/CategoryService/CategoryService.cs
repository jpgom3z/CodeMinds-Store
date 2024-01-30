using API.Data;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly StoreDB _database;

        public CategoryService(StoreDB database) 
        {
            this._database = database;
        }
        public IQueryable<Category> ListCategories()
        {
            return this._database
                .Category
                .Include(c => c.CategoryState);
        }
        public async Task<Category?> FindCategory(int id)
        {
            return await this._database
                    .Category
                    .Include(cs => cs.CategoryState)
                    .Where(c => c.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task InsertCategory(Category entity)
        {
            this._database.Category.Add(entity);
            await this._database.SaveChangesAsync();
            await this._database.Entry(entity).Reference(c => c.CategoryState).LoadAsync();
        }

        public async Task UpdateCategory(Category entity)
        {
            this._database.Category.Update(entity);
            await this._database.SaveChangesAsync();
            await this._database.Entry(entity).Reference(c => c.CategoryState).LoadAsync();
        }

        public async Task DisableCategory(Category entity)
        {
            entity.CategoryStateId = 2;
            this._database.Category.Update(entity);
            await this._database.SaveChangesAsync();
            await this._database.Entry(entity).Reference(c => c.CategoryState).LoadAsync();
        }

        public async Task EnableCategory(Category entity)
        {
            entity.CategoryStateId = 1;
            this._database.Category.Update(entity);
            await this._database.SaveChangesAsync();
            await this._database.Entry(entity).Reference(c => c.CategoryState).LoadAsync();
        }
    }
}
