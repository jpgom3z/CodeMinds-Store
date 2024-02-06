﻿using API.Data;
using API.Data.Filters;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace API.Services
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
                                && (!filter.DateTo.HasValue || o.Date <= filter.DateTo)
                                && (string.IsNullOrWhiteSpace(filter.CustomerDocumentId) || o.CustomerDocumentId.Contains(filter.CustomerDocumentId))
                                && (string.IsNullOrWhiteSpace(filter.CustomerName) || o.CustomerName.Contains(filter.CustomerName))
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

        public async Task InsertOrder(Order entity, OrderProduct orderProduct)
        {
            this._database.Order.Add(entity);
            await this._database.SaveChangesAsync();
            this._database.OrderProduct.Add(orderProduct);
            await this._database .SaveChangesAsync();
        }
        //para revisar commit//
    }
}
