using Epicenter.Domain.Models;
using Epicenter.Domain.Models.Abstract;
using System.Collections.Generic;

namespace Epicenter.Domain.Abstract
{
    public interface ITimestampRepository : IRepository<Timestamp>
    {
        IEnumerable<Timestamp> GetByModelID<T>(int id) where T : MissingModel;
        Timestamp GetLatestModelTimestamp<T>(int id) where T : MissingModel;
    }
}
