using API.Data.Models;
using API.DataTransferObjects;
using API.Services;
using API.Validators;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryValidator _categoryValidator;

        public CategoryController(IMapper mapper, ICategoryService categoryService, ICategoryValidator categoryValidator) 
        {
            this._mapper = mapper;
            this._categoryService = categoryService;
            this._categoryValidator = categoryValidator;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> ListCategories()
        {
            List<Category> list = await this._categoryService.ListCategories().ToListAsync();

            APIResponse response = new()
            {
                Data = list.Select(c => this._mapper.Map<Category, GetCategoryDTO>(c))
            };

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> FindCategory(int id)
        {
            Category? category = await this._categoryService.FindCategory(id);
            if (category == null)
            {
                return HttpErrors.NotFound("Categoría no existe en el sistema");
            }

            APIResponse response = new()
            {
                Data = this._mapper.Map<Category, GetCategoryDTO>(category)
            };

            return response;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> InsertCategory(InsertUpdateCategoryDTO data)
        {
            APIResponse response = new();
            response.Success = this._categoryValidator.ValidateInsertUpdate(null, data, response.Messages);

            if (response.Success)
            {
                Category category = this._mapper.Map<InsertUpdateCategoryDTO, Category>(data);
                await this._categoryService.InsertCategory(category);
                response.Data = this._mapper.Map<Category, GetCategoryDTO>(category);
                response.Messages.Add("Categoría ha sido insertada");
            }

            return response;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> UpdateCategory(int id, InsertUpdateCategoryDTO data)
        {
            Category? category = await this._categoryService.FindCategory(id);
            if (category == null)
            {
                return HttpErrors.NotFound("Categoría no existe en el sistema");
            }

            APIResponse response = new();
            response.Success = this._categoryValidator.ValidateInsertUpdate(null, data, response.Messages);

            if (response.Success)
            {
                this._mapper.Map(data, category);
                await this._categoryService.UpdateCategory(category);
                response.Data = this._mapper.Map<Category, GetCategoryDTO>(category);
                response.Messages.Add("Categoría ha sido actualizada");
            }

            return response;
        }

        //[HttpPost]
        //[Route("{id}/disable")]
        //public async Task<ActionResult<APIResponse>> DisableCategory(int id)
        //{
        //    Category? category = await this._categoryService.FindCategory(id);
        //    if (category == null)
        //    {
        //        return HttpErrors.NotFound("La categoría no existe en el sistema");
        //    }

        //    APIResponse response = new();
            //response.Success = this._doctorValidator.ValidateDelete(id, response.Messages);

            //if (response.Success)
            //{
                //await this._categoryService.DisableCategory(category);
                //response.Data = this._mapper.Map<Category, GetCategoryDTO>(category);
                //response.Messages.Add("Categoría ha sido desactivada");
            //}

        //    return response;
        //}

        //[HttpPost]
        //[Route("{id}/enable")]
        //public async Task<ActionResult<APIResponse>> EnableCategory(int id)
        //{
        //    Category? category = await this._categoryService.FindCategory(id);
        //    if (category == null)
        //    {
        //        return HttpErrors.NotFound("La categoría no existe en el sistema");
        //    }

        //    APIResponse response = new();
        //    //response.Success = this._doctorValidator.ValidateDelete(id, response.Messages);

        //    //if (response.Success)
        //    //{
        //    await this._categoryService.EnableCategory(category);
        //    response.Data = this._mapper.Map<Category, GetCategoryDTO>(category);
        //    response.Messages.Add("Categoría ha sido activada");
        //    //}

        //    return response;
        //}
    }
}
