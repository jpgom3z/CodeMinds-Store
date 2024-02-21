using API.Data;
using API.Data.Filters;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;
    public class OrderService : IOrderService
    {
        private readonly StoreDB _database;
        private readonly IProductService _productService;
        public OrderService(StoreDB database, ProductService productService)
        {
            this._database = database;
            this._productService = productService;
        }
        public IQueryable<Order> ListOrders(OrderListFilter? filter = null)
        {
            filter ??= new OrderListFilter();
            return this._database
                    .Order
                    .Include(o => o.Date)
                    .Include(o => o.CustomerName)
                    .Include(o => o.CustomerDocumentId)
                    .Include(o => o.TotalPrice)
                    .Where(o => (!filter.DateFrom.HasValue || o.Date >= filter.DateFrom)
                                &&(!filter.DateTo.HasValue || o.Date <= filter.DateTo)
                                && (string.IsNullOrWhiteSpace(filter.CustomerName) || o.CustomerName.Contains(filter.CustomerName))
                                && (string.IsNullOrWhiteSpace(filter.CustomerDocumentId) || o.CustomerDocumentId.Contains(filter.CustomerDocumentId))
                                && (!filter.TotalPriceFrom.HasValue || o.TotalPrice >= filter.TotalPriceFrom)
                                && (!filter.TotalPriceTo.HasValue || o.TotalPrice <= filter.TotalPriceTo));
                      /* PREGUNTAR SI REQUIERE EN LA LISTA AL CLIENTE*/
    }
    public async Task<Order?> FindOrder(int id, string customerName, string customerDocumentId)
        {
            return await this._database
                    .Order
                    .Where(o => (o.Id == id) || (o.CustomerName == customerName) || (o.CustomerDocumentId == customerDocumentId))
                    .FirstOrDefaultAsync();
        }

        public async Task InsertOrder(Order entity, OrderProduct orderProduct)
        {
            this._database.Order.Add(entity);
            await this._database.SaveChangesAsync();
            this._database.OrderProduct.Add(orderProduct);
            await this._database.SaveChangesAsync();
        }
    }
