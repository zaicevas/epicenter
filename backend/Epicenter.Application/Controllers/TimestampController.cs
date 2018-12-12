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
        private readonly IPlateRepository _plateRepository;

        public TimestampController(ITimestampRepository timestampRepository, IPlateRepository plateRepository)
        {
            _timestampRepository = timestampRepository;
            _plateRepository = plateRepository;
        }

        [Route("timestamps")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetAll()
        {
            List<Timestamp> timestamps;
            List<TimestampResponse> timestampResponses = new List<TimestampResponse>();
            try
            {
                timestamps = _timestampRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }

            timestamps.ForEach(timestamp =>
            {
                string numberPlate = "";
                if (timestamp.MissingModel.GetType() == typeof(Plate))
                    numberPlate = _plateRepository.GetById(timestamp.MissingModel.Id).NumberPlate;

                timestampResponses.Add(new TimestampResponse()
                {
                    DateAndTime = timestamp.DateAndTime,
                    MissingModelResponse = new MissingModelResponse
                    {
                        FirstName = timestamp.MissingModel.FirstName,
                        LastName = timestamp.MissingModel.LastName,
                        NumberPlate = numberPlate
                    }
                });
            });
            return Ok(timestampResponses.ToArray());
        }
    }
}
