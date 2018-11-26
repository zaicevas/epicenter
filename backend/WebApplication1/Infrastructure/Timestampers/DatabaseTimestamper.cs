using System;
using WebApplication1.Infrastructure.Extensions;
using WebApplication1.Infrastructure.Timestampers.Abstract;
using WebApplication1.Infrastructure.Utils;
using WebApplication1.Models;
using WebApplication1.Models.Abstract;
using WebApplication1.Repositories;

namespace WebApplication1.Infrastructure.Timestampers
{
    public class DatabaseTimestamper<T> : ITimestamper<T> where T : Model
    {
        private readonly TimestampRepository _timestampRepository;

        public DatabaseTimestamper(TimestampRepository timestampRepository)
        {
            _timestampRepository = timestampRepository;
        }

        public void Save(T entity, DateTime dateTime)
        {
            string dateAndTime = dateTime.GetFormattedDateAndTime();
            if (typeof(T) == typeof(Person))
                _timestampRepository.Add(new Timestamp(entity.ID, null, dateAndTime));
            else
                _timestampRepository.Add(new Timestamp(null, entity.ID, dateAndTime));
        }
    }
}