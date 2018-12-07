using Epicenter.Domain.Models.Attributes.Database;

namespace Epicenter.Domain.Models.Abstract
{
    public abstract class Model
    {
        [NonDatabase]
        [ID]
        public int ID { get; set; }
    }
}
