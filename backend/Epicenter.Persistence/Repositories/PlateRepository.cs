using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Epicenter.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epicenter.Persistence.Repositories
{
    public class PlateRepository : IPlateRepository
    {
        private readonly EpicenterDbContext _dbContext;

        public PlateRepository(EpicenterDbContext context)
        {
            _dbContext = context;
        }

        public void Add(Plate entity)
        {
            _dbContext.Plates.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Plate entity)
        {
            _dbContext.Plates.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Edit(Plate entity)
        {
            _dbContext.Plates.Update(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Plate> GetAll()
        {
            return _dbContext.Plates.AsEnumerable();
        }

        public IEnumerable<Plate> Get(Func<Plate, bool> predicate)
        {
            return GetAll().Where(predicate).AsEnumerable();
        }

        public Plate GetById(int id)
        {
            return _dbContext.Plates.Single(x => x.Id == id);
        }

        public Plate GetByPlateNumber(string number)
        {
            return _dbContext.Plates.Single(x => x.NumberPlate == number);
        }
    }
}
