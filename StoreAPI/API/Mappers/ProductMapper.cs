using API.Data.Filters;
using API.Data.Models;
using API.DataTransferObjects;
using AutoMapper;

namespace API.Mappers
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, GetProductDTO>();
            CreateMap<InsertUpdateProductDTO, Product>();
            CreateMap<FilterProductDTO, ProductListFilter>();
        }
    }
}