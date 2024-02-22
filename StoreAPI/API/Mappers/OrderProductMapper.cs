using API.Data.Models;
using API.DataTransferObjects;
using AutoMapper;
namespace API.Mappers
{
    public class OrderProductMapper : Profile
    {
        public OrderProductMapper()
        {
            CreateMap<InsertOrderProductDTO, OrderProduct>();
        }
    }
}