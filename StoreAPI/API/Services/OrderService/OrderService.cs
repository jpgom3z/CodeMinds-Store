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
        public IQueryable<Order> ListOrders(/*OrderListFilter? filter = null*/)
        {
            //FILTER SHOULD BE ADDED HERE

            return this._database
                    .Order;
        }
        public async Task<Order?> FindOrder(int id)
        {
            return await this._database
                    .Order
                    .Where(o => o.Id == id)
                    .FirstOrDefaultAsync();
        }

        //TASK CreateOrder SHOULD BE ADDED HERE
    }
}
