using System;
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

        public void Save(T entity)
        {
            string dateAndTime = DateAndTimeFormatter.GetFormattedDateAndTime(DateTime.Now);
            _timestampRepository.Add(new Timestamp(typeof(T), entity.ID, dateAndTime));
        }
    }
}