using API.Data;
using API.Data.Filters;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace API.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly StoreDB _database;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        public OrderProductService(StoreDB database, IOrderService orderService, IProductService productService)
        {
            this._database = database;
            this._orderService = orderService;
            this._productService = productService;
        }
        public IQueryable<OrderProduct> ListOrderProducts(OrderProductListFilter? filter = null)
        {
            filter ??= new OrderProductListFilter();

            IQueryable<Order> orders = this._orderService.ListOrders(filter.Order);
            IQueryable<Product> products = this._productService.ListProducts(filter.Product);

            return this._database
                .OrderProduct
                    .Include(a => a.Order)
                    .Include(a => a.Order.Id)
                    .Include(a => a.Product)
                    .Include(a => a.Quantity)
                    .Include(a => a.ProductPrice)
                    .Where(a => orders.Contains(a.Order)
                                && products.Contains(a.Product));
        }
        public async Task<OrderProduct?> FindOrderProduct(int id)
        {
            return await this._database
                .OrderProduct
                .Where(op => op.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
