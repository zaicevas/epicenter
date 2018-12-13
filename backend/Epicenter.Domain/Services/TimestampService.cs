using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Epicenter.Domain.Models.Abstract;
using Epicenter.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epicenter.Domain.Services
{
    public class TimestampService
    {
        private readonly ITimestampRepository _timestampRepository;
        private readonly IPlateRepository _plateRepository;

        public TimestampService(ITimestampRepository timestampRepository, IPlateRepository plateRepository)
        {
            _timestampRepository = timestampRepository;
            _plateRepository = plateRepository;
        }

        public IEnumerable<Timestamp> GetLaterThan(DateTime? dateTime)
        {
            IEnumerable<Timestamp> timestamps;
            try
            {
                timestamps = _timestampRepository.GetAll().OrderByDescending(x => x.DateTime);
            }
            catch
            {
                throw;
            }
            if(dateTime != null)
                timestamps = timestamps.Where(x => x.DateTime >= dateTime);
            return timestamps;
        }

        public IEnumerable<Timestamp> GetLaterThan<T>(DateTime? dateTime) where T : MissingModel
        {
            IEnumerable<Timestamp> timestamps = GetLaterThan(dateTime);
            if(typeof(T) == typeof(Person))
                return timestamps.Where(x => x.MissingModel.GetType() == typeof(Person));
            return timestamps.Where(x => x.MissingModel.GetType() == typeof(Plate));
        }

        public IEnumerable<Timestamp> GetLaterThanByModelId<T>(int id, DateTime? dateTime) where T : MissingModel
        {
            IEnumerable<Timestamp> timestamps = GetLaterThan<T>(dateTime);
            return timestamps.Where(x => x.MissingModelId == id);
        }

        public List<TimestampResponse> GenerateResponse(IEnumerable<Timestamp> timestamps)
        {
            List<TimestampResponse> response = new List<TimestampResponse>();
            timestamps.ToList().ForEach(timestamp =>
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
