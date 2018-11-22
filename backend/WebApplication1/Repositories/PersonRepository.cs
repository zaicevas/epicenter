using System.Collections.Generic;
using System.Linq;
using WebApplication1.Mappers;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        public void Add(Person entity)
        {
            Mapper<Person>.CreateRow(entity);
        }

        public void Delete(Person entity)
        {
            Mapper<Person>.DeleteRow(entity);
        }

        public void Edit(Person entity)
        {
            Mapper<Person>.UpdatePerson(entity);
        }

        public IEnumerable<Person> GetAll()
        {
            return Mapper<Person>.ReadRows();
        }

        public Person GetByID(int id)
        {
            return (Person)GetAll().Where(x => x.ID == id);
        }
    }
}
