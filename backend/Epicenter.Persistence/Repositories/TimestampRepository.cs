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
        private readonly EpicenterDbContext _dbContext;

        public TimestampRepository(EpicenterDbContext context)
        {
            _dbContext = context;
        }

        public void Add(Timestamp entity)
        {
            _dbContext.Timestamps.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Timestamp entity)
        {
            _dbContext.Timestamps.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Edit(Timestamp entity)
        {
            _dbContext.Timestamps.Update(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Timestamp> Get(Func<Timestamp, bool> predicate)
        {
            // TODO: switch to EF and use Expression<<Timestamp, bool>> predicate
            return GetAll().Where(predicate).AsEnumerable();
        }

        public IEnumerable<Timestamp> GetAll()
        {
            return _dbContext.Timestamps.AsEnumerable();
        }

        public Timestamp GetById(int id)
        {
            return _dbContext.Timestamps.Single(x => x.Id == id);
        }

        public IEnumerable<Timestamp> GetByModelId(int id)
        {
            return _dbContext.Timestamps.Where(x => x.MissingModelId == id);
        }

        public Timestamp GetLatestModelTimestamp(int id)
        {
            IEnumerable<Timestamp> timestamps = GetByModelId(id);
            return timestamps.OrderByDescending(x => x.DateAndTime).FirstOrDefault();
        }
    }
}