using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("errors")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public ErrorController(IWebHostEnvironment env)
        {
            this._env = env;
        }

        [Route("{statusCode}")]
        public ObjectResult HandleStatus(HttpStatusCode statusCode)
        {
            APIResponse response = new()
            {
                StatusCode = statusCode,
                Success = false
            };

            switch (response.StatusCode)
            {
                case HttpStatusCode.InternalServerError:
                    response.Messages.Add("Ha ocurrido un error desconocido del servidor");

                    if (this._env.IsDevelopment())
                    {
                        Exception? ex = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error;

                        response.Data = new
                        {
                            Message = ex.Message,
                            StackTrace = ex.StackTrace,
                            InnerException = ex.InnerException?.Message,
                            Source = ex.Source,
                            HResult = ex.HResult
                        };
                    }
                    break;
            }

            ObjectResult result = new(response)
            {
                StatusCode = (int)statusCode
            };

            return result;
        }
    }
}
