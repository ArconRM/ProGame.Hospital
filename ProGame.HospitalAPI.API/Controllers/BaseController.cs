using Microsoft.Extensions.Logging;
using ProGame.HospitalAPI.API.ViewModels;
using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.API.Controllers
{
    public abstract class BaseController
    {
        protected readonly ILogger<BaseController> _logger;
        protected async Task<Response<T>> GetResponseFromResultAsync<T>(Func<Task<ActionResult<T>>> func)
        {
            var result = await func();
            if (result.Value is null)
            {
                return Response<T>.GetErrorResponse(result.Exceptions);
            } 
            else
            {
                return new Response<T>(result.Value);
            }
        }
    }
}
