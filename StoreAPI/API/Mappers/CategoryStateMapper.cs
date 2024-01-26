using API.Data.Models;
using API.DataTransferObjects;
using AutoMapper;

namespace API.Mappers
{
    public class CategoryStateMapper : Profile
    {
        public CategoryStateMapper() 
        {
            CreateMap<CategoryState, GetCategoryStateDTO>();
        }
    }
}
