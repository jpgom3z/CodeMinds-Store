using API.Data.Filters;
using API.Data.Models;
using API.DataTransferObjects;
using API.Services;
using API.Validators.OrderValidator;
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
        private readonly IOrderValidator _orderValidator;

        public OrderController(IMapper mapper, IOrderService orderService, IOrderValidator orderValidator)
        {
            this._mapper = mapper;
            this._orderService = orderService;
            this._orderValidator = orderValidator;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> ListOrders([FromQuery] FilterOrderDTO data)
        {
            OrderListFilter filter = this._mapper.Map<FilterOrderDTO, OrderListFilter>(data);

            List<Order> list = await this._orderService.ListOrders(filter)
                                    .OrderBy(o => o.Date)
                                    .ToListAsync();

            APIResponse response = new APIResponse()
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

        [HttpPost]
        public async Task<ActionResult<APIResponse>> InsertPurchaseInsertPurchaseProduct(OrderRequest request)
        {
            APIResponse response = new();
            response.Success = this._orderValidator.ValidateInsert(request, response.Messages);
            if (response.Success)
            {
                Order? order = this._mapper.Map<InsertOrderDTO, Order>(request.OrderData);
                List<OrderProduct> orderProductList = this._mapper.Map<List<InsertOrderProductDTO>, List<OrderProduct>>(request.OrderProductData);
                await this._orderService.InsertOrderProducts(order, orderProductList);
                response.Data = "Estamos trabajando en esto...";
                response.Messages.Add("La compra ha sido insertada");
            }
            return response;
        }

    }
}
