using API.Data.Filters;
using API.Data.Models;

namespace API.Services;
    public interface IOrderService
    {
        IQueryable<Order> ListOrders(OrderListFilter? filter = null);
        Task<Order?> FindOrder(int id, string customerName, string customerDocumentId);
        Task InsertOrder(Order entity, OrderProduct orderProduct);
    }
}
