using API.Data.Models;
using API.DataTransferObjects;
using API.Services;
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

        public CategoryController(IMapper mapper, ICategoryService categoryService) 
        {
            this._mapper = mapper;
            this._categoryService = categoryService;
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
        public async Task<ActionResult<APIResponse>> Insert(InsertUpdateDoctorDTO data)
        {
            APIResponse response = new();
            response.Success = this._doctorValidator.ValidateInsertUpdate(null, data, response.Messages);

            if (response.Success)
            {
                Doctor doctor = this._mapper.Map<InsertUpdateDoctorDTO, Doctor>(data);
                await this._doctorService.InsertDoctor(doctor);
                response.Data = this._mapper.Map<Doctor, GetDoctorDTO>(doctor);
                response.Messages.Add("Doctor ha sido insertado");
            }

            return response;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> UpdateDoctor(int id, InsertUpdateDoctorDTO data)
        {
            Doctor? doctor = await this._doctorService.FindDoctor(id);
            if (doctor == null)
            {
                return HttpErrors.NotFound("Doctor no existe en el sistema");
            }

            APIResponse response = new();
            response.Success = this._doctorValidator.ValidateInsertUpdate(id, data, response.Messages);

            if (response.Success)
            {
                this._mapper.Map(data, doctor);
                await this._doctorService.UpdateDoctor(doctor);
                response.Data = this._mapper.Map<Doctor, GetDoctorDTO>(doctor);
                response.Messages.Add("Doctor ha sido actualizado");
            }

            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteDoctor(int id)
        {
            Doctor? doctor = await this._doctorService.FindDoctor(id);
            if (doctor == null)
            {
                return HttpErrors.NotFound("Doctor no existe en el sistema");
            }

            APIResponse response = new();
            response.Success = this._doctorValidator.ValidateDelete(id, response.Messages);

            if (response.Success)
            {
                await this._doctorService.DeleteDoctor(doctor);
                response.Data = this._mapper.Map<Doctor, GetDoctorDTO>(doctor);
                response.Messages.Add("Doctor ha sido borrado");
            }

            return response;
        }
    }
}
