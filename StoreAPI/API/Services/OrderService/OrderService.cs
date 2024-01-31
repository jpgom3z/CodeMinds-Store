using API.Data;
using API.Data.Filters;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly StoreDB _database;
        public OrderService(StoreDB database)
        {
            this._database = database;
        }
        public IQueryable<Order> ListOrders(OrderListFilter? filter = null)
        {
            filter ??= new OrderListFilter();
            return this._database
                    .Order
                    .Where(o => (!filter.DateFrom.HasValue || o.Date >= filter.DateFrom)
                                && (!filter.TotalPriceFrom.HasValue || o.TotalPrice >= filter.TotalPriceFrom)
                                && (!filter.TotalPriceTo.HasValue || o.TotalPrice <= filter.TotalPriceTo));
        }
        public async Task<Order?> FindOrder(int id)
        {
            return await this._database
                    .Order
                    .Where(o => o.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task InsertOrder(Order entity)
        {
            this._database.Order.Add(entity);
            await this._database.SaveChangesAsync();
        }
    }
}
