using Epicenter.Domain.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}