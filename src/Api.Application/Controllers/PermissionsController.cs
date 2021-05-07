using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Filters;
using Api.Domain.Dtos.Permission;
using Api.Domain.Interfaces.Services.Permission;
using Api.Domain.QueryOptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Api.Domain.Interfaces.QueryOptions;
using Domain.Interfaces.QueryOptions;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [EnableCors]
    [EnableCors("MyAllowSpecificOrigins")]
    public class PermissionsController : ControllerBase
    {
        public IPermissionService _service { get; set; }
        public PermissionsController(IPermissionService service)
        {
            _service = service;
        }

        // [Authorize("Bearer")]
        // [AuthorizeClaim("Permissions", "permission-list")]
        [HttpPost("GetAll")]
        public async Task<ActionResult> GetAll([FromBody] QueryOptionsInput query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                // return null;
                return Ok(await _service.GetAll(query));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [AuthorizeClaim("Permissions", "permission-detail")]
        [HttpGet]
        [Route("{id}", Name = "GetPermissionWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Get(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [AuthorizeClaim("Permissions", "permission-insert")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PermissionDto permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(permission);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetPermissionWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [AuthorizeClaim("Permissions", "permission-edit")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PermissionDto permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Put(permission);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [AuthorizeClaim("Permissions", "permission-delete")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
