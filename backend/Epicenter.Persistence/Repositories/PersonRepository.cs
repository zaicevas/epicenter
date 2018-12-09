using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Epicenter.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epicenter.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly EpicenterContext _context;

        public PersonRepository(EpicenterContext context)
        {
            _context = context;
        }

        public void Add(Person entity)
        {
            _context.People.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Person entity)
        {
            _context.People.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Person entity)
        {
            _context.People.Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.People.AsEnumerable();
        }

        public IEnumerable<Person> Get(Func<Person, bool> predicate)
        {
            return GetAll().Where(predicate).AsEnumerable();
        }

        public Person GetByID(int id)
        {
            return _context.People.Single(x => x.Id == id);
        }

        public Person GetByFaceAPIID(string id)
        {
            return _context.People.Single(x => x.FaceAPIId == id);
        }
    }
}
