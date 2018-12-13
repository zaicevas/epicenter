using Epicenter.Application.Models.DTO.Responses;
using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using System.Collections.Generic;

namespace Epicenter.Application.Controllers.Delegates
{
    public class TimestampDelegate
    {
        private readonly IPlateRepository _plateRepository;

        public TimestampDelegate(IPlateRepository plateRepository)
        {
            _plateRepository = plateRepository;
        }

        public List<TimestampResponse> CreateResponse(List<Timestamp> timestamps)
        {
            List<TimestampResponse> response = new List<TimestampResponse>();
            timestamps.ForEach(timestamp =>
            {
                string numberPlate = "";
                if (timestamp.MissingModel.GetType() == typeof(Plate))
                    numberPlate = _plateRepository.GetById(timestamp.MissingModel.Id).NumberPlate;
                response.Add(new TimestampResponse()
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
            return response;
        }
    }
}
