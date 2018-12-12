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
        private readonly EpicenterDbContext _dbContext;

        public PersonRepository(EpicenterDbContext context)
        {
            _dbContext = context;
        }

        public void Add(Person entity)
        {
            _dbContext.People.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Person entity)
        {
            _dbContext.People.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Edit(Person entity)
        {
            _dbContext.People.Update(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Person> GetAll()
        {
            return _dbContext.People.AsEnumerable();
        }

        public IEnumerable<Person> Get(Func<Person, bool> predicate)
        {
            return GetAll().Where(predicate).AsEnumerable();
        }

        public Person GetById(int id)
        {
            return _dbContext.People.Single(x => x.Id == id);
        }

        public Person GetByFaceAPIId(string id)
        {
            return _dbContext.People.Single(x => x.FaceAPIId == id);
        }
    }
}
