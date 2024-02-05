using API.Data.Filters;
using API.Data.Models;

namespace API.Services
{
    public interface IOrderProductService
    {
        IQueryable<OrderProduct> ListOrderProducts(OrderProductListFilter? filter = null);
        Task<OrderProduct?> FindOrderProduct(int id);
        Task InsertOrderProduct(OrderProduct order);
        Task UpdateOrderProduct(OrderProduct orderProduct);
        Task DeleteOrderProduct(OrderProduct entity);
    }
}
