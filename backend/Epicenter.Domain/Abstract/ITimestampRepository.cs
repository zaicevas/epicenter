using Epicenter.Domain.Models;
using System.Collections.Generic;

namespace Epicenter.Domain.Abstract
{
    public interface ITimestampRepository : IRepository<Timestamp>
    {
        IEnumerable<Timestamp> GetByModelId(int id);
        Timestamp GetLatestModelTimestamp(int id);
    }
}
