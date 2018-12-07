using Epicenter.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Epicenter.Domain.Abstract
{
    public interface IRepository<T> where T : Model
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Func<T, bool> predicate);
        // TODO: Introduce EF and use Expression<Func<T, bool>> predicate
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
