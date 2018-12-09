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

        public Timestamp GetById(int id)
        {
            return _context.Timestamps.Single(x => x.Id == id);
        }

        public IEnumerable<Timestamp> GetByModelId(int id)
        {
            return _context.Timestamps.Where(x => x.MissingModelId == id);
        }

        public Timestamp GetLatestModelTimestamp(int id)
        {
            IEnumerable<Timestamp> timestamps = GetByModelId(id);
            return timestamps.OrderByDescending(x => x.DateAndTime).FirstOrDefault();
        }
    }
}