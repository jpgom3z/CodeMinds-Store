using API.Data.Filters;
using API.Data.Models;
namespace API.Services
{
    public interface IProductService
    {
        IQueryable<Product> ListProducts(ProductListFilter? filter = null);
        Task<Product?> FindProduct(int id);
        Task InsertProduct(Product entity);
        Task UpdateProduct(Product entity);
    }
}