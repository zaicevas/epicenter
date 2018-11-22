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
        public void Add(Plate entity)
        {
            Mapper<Plate>.CreateRow(entity);
        }

        public void Delete(Plate entity)
        {
            Mapper<Plate>.DeleteRow(entity);
        }

        public void Edit(Plate entity)
        {
            Mapper<Plate>.Update(entity);
        }

        public IEnumerable<Plate> GetAll()
        {
            return Mapper<Plate>.ReadRows();
        }

        public Plate GetByID(int id)
        {
            return Mapper<Plate>.ReadByID(id);
        }

        public Plate GetByPlateNumber(string number)
        {
            return Mapper<Plate>.ReadByKey<PrimaryKeyAttribute>(new Plate(number));
        }
    }
}
