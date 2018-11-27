using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Abstract;

namespace WebApplication1.Repositories.Abstract
{
    // Model has property ID
    interface IRepository<T> where T : Model
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
