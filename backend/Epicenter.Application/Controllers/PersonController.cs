using Epicenter.Domain.Models;
using Epicenter.Domain.Models.DTO;
using Epicenter.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Epicenter.Application.Controllers
{
    [Route("api")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [Route("missing/persons")]
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetPersons()
        {
            return Ok(_personService.GetAllMissingPersons());
        }

        [Route("person")]
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PutPersonAsync([FromBody] PersonRequest request)
        {
            try
            {
                await _personService.CreateAsync(request);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            return Ok();
        }

        [Route("person/{id}")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PostPersonAsync(int id, [FromBody] PersonRequest request)
        {
            try
            {
                await _personService.UpdateAsync(id, request);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok();
        }

        [Route("person/{id}")]
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeletePersonAsync(int id)
        {
            try
            {
                await _personService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok();
        }
    }
}