using API.Data;
using API.Data.Filters;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;
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
                                &&(!filter.DateTo.HasValue || o.Date <= filter.DateTo)
                                && (string.IsNullOrWhiteSpace(filter.CustomerName) || o.CustomerName.Contains(filter.CustomerName))
                                && (string.IsNullOrWhiteSpace(filter.CustomerDocumentId) || o.CustomerDocumentId.Contains(filter.CustomerDocumentId))
                                && (!filter.TotalPriceFrom.HasValue || o.TotalPrice >= filter.TotalPriceFrom)
                                && (!filter.TotalPriceTo.HasValue || o.TotalPrice <= filter.TotalPriceTo));
    }
    public async Task<Order?> FindOrder(int id)
        {
            return await this._database
                    .Order
                    .Where(o => (o.Id == id))
                    .FirstOrDefaultAsync();
        }

        public async Task InsertOrderProducts(Order OrderEntity, List<OrderProduct> OrderProductEntities)
        {
        // Insertamos un elemento Order a la DB
        this._database.Order.Add(OrderEntity);
        await this._database.SaveChangesAsync();

        // Obtenemos el ID del elemento Order insertado
        int newOrderId = OrderEntity.Id;

        //// Insertamos en la DB un elemento OrderProduct por cada objeto que traiga la lista 
        foreach (var orderProductEntity in OrderProductEntities)
        {
            // Asignamos el ID del elemento Order como valor de OrderProduct.OrderId
            orderProductEntity.OrderId = newOrderId;
            this._database.OrderProduct.Add(orderProductEntity);
        }
        await this._database.SaveChangesAsync();
    }
    }
