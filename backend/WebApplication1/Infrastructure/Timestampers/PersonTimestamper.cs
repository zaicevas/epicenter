using System;
using WebApplication1.Infrastructure.Timestampers.Abstract;
using WebApplication1.Infrastructure.Utils;
using WebApplication1.Models;
using WebApplication1.Repositories;
using static WebApplication1.Models.Timestamp;

namespace WebApplication1.Infrastructure.Timestampers
{
    public class PersonTimestamper : ITimestamper<Person>
    {
        private readonly TimestampRepository _timestampRepository;

        public PersonTimestamper(TimestampRepository logRepository)
        {
            _timestampRepository = logRepository;
        }

        public void Save(Person entity)
        {
            string dateAndTime = DateAndTimeFormatter.GetFormattedDateAndTime(DateTime.Now);
            _timestampRepository.Add(new Timestamp(LoggableEntity.Person, dateAndTime, entity.ID));
        }
    }
}
