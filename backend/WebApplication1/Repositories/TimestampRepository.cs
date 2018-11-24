using System.Collections.Generic;
using WebApplication1.Mappers;
using WebApplication1.Models;
using WebApplication1.Repositories.Abstract;

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
    }
}
