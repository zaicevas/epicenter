using System.Collections.Generic;
using WebApplication1.Mappers;
using WebApplication1.Models;
using WebApplication1.Repositories.Abstract;

namespace WebApplication1.Repositories
{
    public class LogRepository : IRepository<Log>
    {
        private readonly Mapper<Log> _mapper;

        public LogRepository(Mapper<Log> mapper)
        {
            _mapper = mapper;
        }

        public void Add(Log entity)
        {
            _mapper.CreateRow(entity);
        }

        public void Delete(Log entity)
        {
            _mapper.DeleteRow(entity);
        }

        public void Edit(Log entity)
        {
            _mapper.Update(entity);
        }

        public IEnumerable<Log> GetAll()
        {
            return _mapper.ReadRows();
        }

        public Log GetByID(int id)
        {
            return _mapper.ReadByID(id);
        }
    }
}
