using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class VerifyLoginController : ControllerBase
    {
        // [Authorize("Bearer")]
        [AllowAnonymous]
        [HttpGet("{token}")]
        public async Task<object> VerifyLogin(string token,
                                          [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (token == null)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await service.VerifyToken(token);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }



    }


}
