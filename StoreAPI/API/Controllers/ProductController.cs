using API.Data.Filters;
using API.Data.Models;
using API.DataTransferObjects;
using API.Services;
using API.Validators.ProductValidator;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IProductValidator _productValidator;
        public ProductController(IMapper mapper, IProductService productService, IProductValidator productValidator)
        {
            this._mapper = mapper;
            this._productService = productService;
            this._productValidator = productValidator;
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> ListProducts([FromQuery] FilterProductDTO data)
        {
            ProductListFilter filter = this._mapper.Map<FilterProductDTO, ProductListFilter>(data);

            List<Product> list = await this._productService.ListProducts(filter)
                                    .OrderBy(p => p.Name)
                                    .ThenBy(p => p.Price)
                                    .ToListAsync();

            APIResponse response = new APIResponse()
            {
                Data = list.Select(p => this._mapper.Map<Product, GetProductDTO>(p))
            };
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> FindProduct(int id)
        {
            Product? product = await this._productService.FindProduct(id);
            if (product == null)
            {
                return HttpErrors.NotFound("Producto no existe en el sistema");
            }
            APIResponse response = new()
            {
                Data = this._mapper.Map<Product, GetProductDTO>(product)
            };
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> InsertProduct(InsertUpdateProductDTO data)
        {
            APIResponse response = new();
            response.Success = this._productValidator.ValidateInsertUpdate(data, response.Messages);
            if (response.Success)
            {
                Product? product = this._mapper.Map<InsertUpdateProductDTO, Product>(data);
                await this._productService.InsertProduct(product);
                response.Data = this._mapper.Map<Product, GetProductDTO>(product);
                response.Messages.Add("El producto ha sido insertado");
            }
            return response;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> UpdateProduct(int id, InsertUpdateProductDTO data)
        {
            Product? product = await this._productService.FindProduct(id);
            if (product == null) { return HttpErrors.NotFound("Producto no existe en el sistema"); }
            APIResponse response = new();
            response.Success = this._productValidator.ValidateInsertUpdate(data, response.Messages);
            if (response.Success)
            {
                this._mapper.Map(data, product);
                await this._productService.UpdateProduct(product);
                response.Data = this._mapper.Map<Product, GetProductDTO>(product);
                response.Messages.Add("El producto ha sido actualizado");
            }
            return response;
        }
    }
}