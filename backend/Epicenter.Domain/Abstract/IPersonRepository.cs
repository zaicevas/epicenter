using Epicenter.Domain.Models;

namespace Epicenter.Domain.Abstract
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person GetByFaceAPIId(string id);
    }
}
