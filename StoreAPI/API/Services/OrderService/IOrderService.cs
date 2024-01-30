using API.Data.Filters;
using API.Data.Models;

namespace API.Services.OrderService
{
    public interface IOrderService
    {
        IQueryable<Order> ListOrders(/*OrderListFilter? filter = null*/);
        Task<Order?> FindOrder(int id);
        //Task InsertOrder(Product entity);
    }
}
