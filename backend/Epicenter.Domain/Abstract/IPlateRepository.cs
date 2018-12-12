using Epicenter.Domain.Models;

namespace Epicenter.Domain.Abstract
{
    public interface IPlateRepository : IRepository<Plate>
    {
        Plate GetByPlateNumber(string number);
    }
}
