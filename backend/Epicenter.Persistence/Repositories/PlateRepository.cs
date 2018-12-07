using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Epicenter.Domain.Models.Attributes.Database;
using Epicenter.Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epicenter.Persistence.Repositories
{
    public class PlateRepository : IPlateRepository
    {
        private readonly Mapper<Plate> _mapper;

        public PlateRepository(Mapper<Plate> mapper)
        {
            _mapper = mapper;
        }

        public void Add(Plate entity)
        {
            _mapper.CreateRow(entity);
        }

        public void Delete(Plate entity)
        {
            _mapper.DeleteRow(entity);
        }

        public void Edit(Plate entity)
        {
            _mapper.Update(entity);
        }

        public IEnumerable<Plate> GetAll()
        {
            return _mapper.ReadRows();
        }

        public IEnumerable<Plate> Get(Func<Plate, bool> predicate)
        {
            return GetAll().Where(predicate).AsEnumerable();
        }

        public Plate GetByID(int id)
        {
            return _mapper.ReadByID(id);
        }

        public Plate GetByPlateNumber(string number)
        {
            return _mapper.ReadByKey<PrimaryKeyAttribute>(new Plate(number));
        }
    }
}
