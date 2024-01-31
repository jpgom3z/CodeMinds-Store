using API.Data.Models;
using API.DataTransferObjects;
using AutoMapper;

namespace API.Mappers
{
    public class ProductStateMapper : Profile
    {
        public ProductStateMapper()
        {
            CreateMap<ProductState, GetProductStateDTO>();
        }
    }
}
