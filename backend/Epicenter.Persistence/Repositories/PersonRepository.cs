using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Epicenter.Domain.Models.Attributes.Database;
using Epicenter.Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epicenter.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Mapper<Person> _mapper;

        public PersonRepository(Mapper<Person> mapper)
        {
            _mapper = mapper;
        }

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

        public IEnumerable<Person> Get(Func<Person, bool> predicate)
        {
            return GetAll().Where(predicate).AsEnumerable();
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
