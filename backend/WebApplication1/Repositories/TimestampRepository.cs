using System.Collections.Generic;
using WebApplication1.Mappers;
using WebApplication1.Models;
using WebApplication1.Repositories.Abstract;
using System.Linq;
using WebApplication1.Infrastructure.Attributes.Database;

namespace WebApplication1.Repositories
{
    public class TimestampRepository : IRepository<Timestamp>
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

        public IEnumerable<Timestamp> GetAll()
        {
            return _mapper.ReadRows();
        }

        public Timestamp GetByID(int id)
        {
            return _mapper.ReadByID(id);
        }

        ///TODO make generic !!!!
        public IEnumerable<Timestamp> GetByPersonID(int id)
        {
            IEnumerable<Timestamp> allTimestamps = GetAll();
            return allTimestamps.Where(stamp => stamp.PersonID == id);
        }

        public IEnumerable<Timestamp> GetByPlateID(int id)
        {
            IEnumerable<Timestamp> allTimestamps = GetAll();
            return allTimestamps.Where(stamp => stamp.PlateID == id);
        }

        public Timestamp GetLatestPersonTimestamp(int id)
        {
            IEnumerable<Timestamp> timestamps = GetByPersonID(id);
            return timestamps.OrderByDescending(x => x.DateAndTime).FirstOrDefault();
        }

        public Timestamp GetLatestPlateTimestamp(int id)
        {
            IEnumerable<Timestamp> timestamps = GetByPlateID(id);
            return timestamps.OrderByDescending(x => x.DateAndTime).FirstOrDefault();
        }
    }
}