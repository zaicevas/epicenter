using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Epicenter.Domain.Models.Abstract;
using Epicenter.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epicenter.Persistence.Repositories
{
    public class TimestampRepository : ITimestampRepository
    {
        private readonly EpicenterContext _context;

        public TimestampRepository(EpicenterContext context)
        {
            _context = context;
        }

        public void Add(Timestamp entity)
        {
            _context.Timestamps.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Timestamp entity)
        {
            _context.Timestamps.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Timestamp entity)
        {
            _context.Timestamps.Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Timestamp> Get(Func<Timestamp, bool> predicate)
        {
            // TODO: switch to EF and use Expression<<Timestamp, bool>> predicate
            return GetAll().Where(predicate).AsEnumerable();
        }

        public IEnumerable<Timestamp> GetAll()
        {
            return _context.Timestamps.AsEnumerable();
        }

        public Timestamp GetByID(int id)
        {
            return _context.Timestamps.Single(x => x.Id == id);
        }

        public IEnumerable<Timestamp> GetByModelID<T>(int id) where T : MissingModel
        {
            return _context.Timestamps.Where(x => x.MissingModelId == id);
        }

        public Timestamp GetLatestModelTimestamp<T>(int id) where T : MissingModel
        {
            IEnumerable<Timestamp> timestamps = GetByModelID<T>(id);
            return timestamps.OrderByDescending(x => x.DateAndTime).FirstOrDefault();
        }
    }
}