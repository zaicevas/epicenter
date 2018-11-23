using System.Collections.Generic;
using System.Linq;
using WebApplication1.Infrastructure.Attributes.Database;
using WebApplication1.Mappers;
using WebApplication1.Models;
using WebApplication1.Repositories.Abstract;

namespace WebApplication1.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private Mapper<Person> _mapper = new Mapper<Person>();
        public void Add(Person entity)
        {
            _mapper.CreateRow(entity);
        }

        public void Delete(Person entity)
        {
            _mapper.DeleteRow(entity);
        }

        public void Edit(Person entity)
        {
            _mapper.Update(entity);
        }

        public IEnumerable<Person> GetAll()
        {
            return _mapper.ReadRows();
        }

        public Person GetByID(int id)
        {
            return _mapper.ReadByID(id);
        }

        public Person GetByFaceAPIID(string id)
        {
            return _mapper.ReadByKey<PrimaryKeyAttribute>(new Person { FaceAPIID = id });
        }
    }
}
