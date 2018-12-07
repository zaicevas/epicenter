using Epicenter.Domain.Models;

namespace Epicenter.Domain.Abstract
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person GetByFaceAPIID(string id);
    }
}
