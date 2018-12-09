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
        private readonly EpicenterContext _context;

        public PlateRepository(EpicenterContext context)
        {
            _context = context;
        }

        public void Add(Plate entity)
        {
            _context.Plates.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Plate entity)
        {
            _context.Plates.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Plate entity)
        {
            _context.Plates.Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Plate> GetAll()
        {
            return _context.Plates.AsEnumerable();
        }

        public IEnumerable<Plate> Get(Func<Plate, bool> predicate)
        {
            return GetAll().Where(predicate).AsEnumerable();
        }

        public Plate GetById(int id)
        {
            return _context.Plates.Single(x => x.Id == id);
        }

        public Plate GetByPlateNumber(string number)
        {
            return _context.Plates.Single(x => x.NumberPlate == number);
        }
    }
}
