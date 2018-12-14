using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Epicenter.Domain.Models.Abstract;
using Epicenter.Domain.Models.DTO;
using Epicenter.Infrastructure.Extensions;
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
            if (dateTime > DateTime.UtcNow.ToUTC2())
                return Enumerable.Empty<Timestamp>();
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
                ModelType type = ModelType.Person;
                if (timestamp.MissingModel.GetType() == typeof(Plate))
                {
                    numberPlate = _plateRepository.GetById(timestamp.MissingModel.Id).NumberPlate;
                    type = ModelType.Plate;
                }
                response.Add(new TimestampResponse()
                {
                    Id = timestamp.Id,
                    DateAndTime = timestamp.DateAndTime,
                    MissingModel = new MissingModelResponse
                    {
                        Id = timestamp.MissingModel.Id,
                        FirstName = timestamp.MissingModel.FirstName,
                        LastName = timestamp.MissingModel.LastName,
                        Reason = timestamp.MissingModel.Reason,
                        Type = type,
                        Message = numberPlate
                    }
                });
            });
            return response;
        }
    }
}
