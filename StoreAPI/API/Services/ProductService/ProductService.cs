using API.Data;
using API.Data.Filters;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace API.Services

{
    public class ProductService : IProductService
    {
        private readonly StoreDB _database;
        public ProductService(StoreDB database)
        {
            this._database = database;
        }
        public IQueryable<Product> ListProducts(ProductListFilter? filter = null)
        {
            filter ??= new ProductListFilter();
            return this._database
                    .Product
                    .Include(p => p.Category)
                                    .ThenInclude(c => c.CategoryState)
                    .Include(p => p.ProductState)
                    .Where(p => (string.IsNullOrWhiteSpace(filter.Name) || p.Name.Contains(filter.Name))
                                && (!filter.PriceFrom.HasValue || p.Price >= filter.PriceFrom)
                                && (!filter.PriceTo.HasValue || p.Price <= filter.PriceTo)
                                && (!filter.CategoryId.HasValue || p.CategoryId == filter.CategoryId)
                                && (!filter.ProductStateId.HasValue || p.ProductStateId == filter.ProductStateId));
        }

        public async Task<Product?> FindProduct(int id)
        {
            return await this._database
                    .Product
                    .Include(p => p.Category)
                                    .ThenInclude(c => c.CategoryState)
                    .Include(p => p.ProductState)
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();
        }
        public async Task InsertProduct(Product entity)
        {
            this._database.Product.Add(entity);
            await this._database.SaveChangesAsync();
            await this._database.Entry(entity).Reference(p => p.Category).LoadAsync();
            await this._database.Entry(entity).Reference(p => p.ProductState).LoadAsync();
        }
        public async Task UpdateProduct(Product entity)
        {
            this._database.Product.Update(entity);
            await this._database.SaveChangesAsync();
            await this._database.Entry(entity).Reference(p => p.Category).LoadAsync();
            await this._database.Entry(entity).Reference(p => p.ProductState).LoadAsync();
        }
    }
}