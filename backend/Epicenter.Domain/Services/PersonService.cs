using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using System.Collections.Generic;

namespace Epicenter.Domain.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<Person> GetAllMissingPersons()
        {
            return _personRepository.GetAll() as List<Person>;
        }
    }
}
