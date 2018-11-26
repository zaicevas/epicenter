using System;
using WebApplication1.Models.Abstract;

namespace WebApplication1.Infrastructure.Timestampers.Abstract
{
    public interface ITimestamper<T> where T : Model
    {
        void Save(T entity, DateTime time);
    }
}
