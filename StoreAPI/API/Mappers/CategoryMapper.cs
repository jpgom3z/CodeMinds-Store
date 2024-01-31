using API.Data.Filters;
using API.Data.Models;
using API.DataTransferObjects;
using AutoMapper;
using System.Numerics;

namespace API.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper() 
        {
            CreateMap<Category, GetCategoryDTO>();
            CreateMap<InsertUpdateCategoryDTO, Category>();
            CreateMap<FilterCategoryDTO, CategoryListFilter>();
        }
    }
}
