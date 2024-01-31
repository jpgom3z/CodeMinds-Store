using API.Data.Filters;
using API.Data.Models;
using API.DataTransferObjects;
using AutoMapper;

namespace API.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper() 
        {
            CreateMap<Order, GetOrderDTO>();
            CreateMap<InsertOrderDTO, Order>();
            CreateMap<FilterOrderDTO, OrderListFilter>();
        }
    }
}
