using API.Data.Models;
using API.DataTransferObjects;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/productstates")]
    [ApiController]
    public class ProductStateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductStateService _productStateService;

        public ProductStateController(IMapper mapper, IProductStateService productStateService)
        {
            this._mapper = mapper;
            this._productStateService = productStateService;
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> ListProductStates()
        {
            List<ProductState> list = await this._productStateService.ListProductStates().ToListAsync();

            APIResponse response = new()
            {
                Data = list.Select(p => this._mapper.Map<ProductState, GetProductStateDTO>(p))
            };

            return response;
        }
    }
}
