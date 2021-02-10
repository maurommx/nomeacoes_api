using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Associate;
using Api.Domain.Interfaces.Services.Associate;
using Api.Domain.QueryOptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociatesController : ControllerBase
    {
        public IAssociateService _service { get; set; }
        public AssociatesController(IAssociateService service)
        {
            _service = service;
        }

        // [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] QueryOptions query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // 400 Bad Request - Solicitação Inválida
            }
            try
            {
                return Ok(await _service.GetAll(query));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetAssociateWithId")]
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AssociateDtoCreate associate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(associate);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GeAssociatetWithId", new { id = result.Id })), result);
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

        // [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AssociateDtoUpdate associate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Put(associate);
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

        // [Authorize("Bearer")]
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
