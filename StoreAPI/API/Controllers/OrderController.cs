using API.Data.Models;
using API.DataTransferObjects;
using API.Services;
using API.Services.OrderService;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrderController(IMapper mapper, IOrderService orderService)
        {
            this._mapper = mapper;
            this._orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> ListCategories()
        {
            List<Order> list = await this._orderService.ListOrders().ToListAsync();

            APIResponse response = new()
            {
                Data = list.Select(o => this._mapper.Map<Order, GetOrderDTO>(o))
            };

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> FindOrder(int id)
        {
            Order? order = await this._orderService.FindOrder(id);
            if (order == null)
            {
                return HttpErrors.NotFound("Orden de compra no existe en el sistema");
            }

            APIResponse response = new()
            {
                Data = this._mapper.Map<Order, GetOrderDTO>(order)
            };

            return response;
        }
        //HTTP POST For Order Creation SHOULD BE HERE
    }
}
