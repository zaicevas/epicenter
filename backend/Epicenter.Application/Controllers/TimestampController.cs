using Epicenter.Domain.Models;
using Epicenter.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Epicenter.Application.Controllers
{
    [Route("api")]
    [ApiController]
    public class TimestampController : ControllerBase
    {
        private readonly TimestampService _timestampService;

        public TimestampController(TimestampService timestampService)
        {
            _timestampService = timestampService;
        }

        [Route("timestamps")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetTimestamps([FromBody] DateTime? dateTime)
        {
            IEnumerable<Timestamp> timestamps;
            try
            {
                timestamps = _timestampService.GetLaterThan(dateTime);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok(_timestampService.GenerateResponse(timestamps).ToArray());
        }

        [Route("persons/timestamps")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetPersonsTimestamps([FromBody] DateTime? dateTime)
        {
            IEnumerable<Timestamp> timestamps;
            try
            {
                timestamps = _timestampService.GetLaterThan<Person>(dateTime);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok(_timestampService.GenerateResponse(timestamps).ToArray());
        }

        [Route("cars/timestamps")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetCarsTimestamps([FromBody] DateTime? dateTime)
        {
            IEnumerable<Timestamp> timestamps;
            try
            {
                timestamps = _timestampService.GetLaterThan<Plate>(dateTime);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok(_timestampService.GenerateResponse(timestamps).ToArray());
        }

        [Route("persons/{id}/timestamps")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetPersonsTimestampsByModelId(int id, [FromBody] DateTime? dateTime)
        {
            IEnumerable<Timestamp> timestamps;
            try
            {
                timestamps = _timestampService.GetLaterThanByModelId<Person>(id, dateTime);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok(_timestampService.GenerateResponse(timestamps).ToArray());
        }

        [Route("cars/{id}/timestamps")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetCarsTimestampsByModelId(int id, [FromBody] DateTime? dateTime)
        {
            IEnumerable<Timestamp> timestamps;
            try
            {
                timestamps = _timestampService.GetLaterThanByModelId<Plate>(id, dateTime);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok(_timestampService.GenerateResponse(timestamps).ToArray());
        }

        [Route("persons/timestamps/amount")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetXPersonsTimestamps([FromBody] int amount)
        {
            IEnumerable<Timestamp> timestamps;
            try
            {
                timestamps = _timestampService.GetX<Person>(amount);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok(_timestampService.GenerateResponse(timestamps).ToArray());
        }

        [Route("cars/timestamps/amount")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetXCarsTimestamps([FromBody] int amount)
        {
            IEnumerable<Timestamp> timestamps;
            try
            {
                timestamps = _timestampService.GetX<Plate>(amount);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            return Ok(_timestampService.GenerateResponse(timestamps).ToArray());
        }
    }
}
