using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Epicenter.Domain.Models.Abstract;
using Epicenter.Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epicenter.Persistence.Repositories
{
    public class TimestampRepository : ITimestampRepository
    {
        private readonly Mapper<Timestamp> _mapper;

        public TimestampRepository(Mapper<Timestamp> mapper)
        {
            _mapper = mapper;
        }

        public void Add(Timestamp entity)
        {
            _mapper.CreateRow(entity);
        }

        public void Delete(Timestamp entity)
        {
            _mapper.DeleteRow(entity);
        }

        public void Edit(Timestamp entity)
        {
            _mapper.Update(entity);
        }

        public IEnumerable<Timestamp> Get(Func<Timestamp, bool> predicate)
        {
            // TODO: switch to EF and use Expression<<Timestamp, bool>> predicate
            return GetAll().Where(predicate).AsEnumerable();
        }

        public IEnumerable<Timestamp> GetAll()
        {
            return _mapper.ReadRows();
        }

        public Timestamp GetByID(int id)
        {
            return _mapper.ReadByID(id);
        }

        public IEnumerable<Timestamp> GetByModelID<T>(int id) where T : MissingModel
        {
            IEnumerable<Timestamp> allTimestamps = GetAll();
            if (typeof(T) == typeof(Person))
                return allTimestamps.Where(stamp => stamp.PersonID == id);
            return allTimestamps.Where(stamp => stamp.PlateID == id);
        }

        public Timestamp GetLatestModelTimestamp<T>(int id) where T : MissingModel
        {
            IEnumerable<Timestamp> timestamps = GetByModelID<T>(id);
            return timestamps.OrderByDescending(x => x.DateAndTime).FirstOrDefault();
        }
    }
}