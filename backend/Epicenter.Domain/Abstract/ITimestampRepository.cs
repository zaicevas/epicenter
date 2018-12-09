using Epicenter.Domain.Models;
using System.Collections.Generic;

namespace Epicenter.Domain.Abstract
{
    public interface ITimestampRepository : IRepository<Timestamp>
    {
        IEnumerable<Timestamp> GetByModelID(int id);
        Timestamp GetLatestModelTimestamp(int id);
    }
}
