using Epicenter.Application.Controllers.Delegates;
using Epicenter.Application.Models.DTO.Responses;
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
        private readonly TimestampDelegate _timestampDelegate;

        public TimestampController(ITimestampRepository timestampRepository, TimestampDelegate timestampDelegate)
        {
            _timestampRepository = timestampRepository;
            _timestampDelegate = timestampDelegate;
        }

        [Route("timestamps")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetLaterThan([FromBody] DateTime dateTime)
        {
            List<Timestamp> timestamps;
            try
            {
                timestamps = _timestampRepository.GetAll().Where(x => x.DateTime >= dateTime).OrderByDescending(x => x.DateTime).ToList();
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            List<TimestampResponse> response = _timestampDelegate.CreateResponse(timestamps);
            return Ok(response.ToArray());
        }
    }
}
