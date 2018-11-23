using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Infrastructure.Attributes.Database;
using WebApplication1.Mappers;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class PlateRepository
    {
        private Mapper<Plate> _mapper = new Mapper<Plate>();
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
