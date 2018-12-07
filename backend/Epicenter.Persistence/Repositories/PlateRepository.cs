using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Epicenter.Domain.Models.Attributes.Database;
using Epicenter.Persistence.Mappers;
using System.Collections.Generic;

namespace Epicenter.Persistence.Repositories
{
    public class PlateRepository : IRepository<Plate>
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
