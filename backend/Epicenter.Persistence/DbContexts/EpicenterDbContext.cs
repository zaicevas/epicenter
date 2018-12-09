using Epicenter.Domain.Models;
using Epicenter.Domain.Models.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Epicenter.Persistence.DbContexts
{
    public class EpicenterDbContext : DbContext
    {
        public EpicenterDbContext(DbContextOptions<EpicenterDbContext> options)
            : base(options)
        { }

        public DbSet<MissingModel> MissingModels { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Plate> Plates { get; set; }
        public DbSet<Timestamp> Timestamps { get; set; }
    }
}
