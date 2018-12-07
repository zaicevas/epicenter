using Epicenter.Domain.Models.Abstract;
using System.Collections.Generic;

namespace Epicenter.Domain.Abstract
{
    public interface IRepository<T> where T : Model
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
