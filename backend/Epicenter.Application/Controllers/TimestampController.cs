using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epicenter.Application.Controllers
{
    [Route("api")]
    [ApiController]
    public class TimestampController : ControllerBase
    {
        private readonly ITimestampRepository _timestampRepository;

        public TimestampController(ITimestampRepository timestampRepository)
        {
            _timestampRepository = timestampRepository;
        }

        [Route("timestamps")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetAll()
        {
            IEnumerable<Timestamp> timestamps;
            try
            {
                timestamps = _timestampRepository.GetAll();
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok(timestamps.ToArray());
        }
    }
}