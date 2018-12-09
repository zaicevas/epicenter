using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class EpicenterContext : DbContext
    {
        public EpicenterContext(DbContextOptions<EpicenterContext> options)
            : base(options)
        { }

        public DbSet<MissingModel> MissingModels { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Plate> Plates { get; set; }
        public DbSet<Timestamp> Timestamps { get; set; }
    }

    public class MissingModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Reason { get; set; }

        public ICollection<Timestamp> Timestamps { get; set; }
    }

    public class Person : MissingModel
    {
        public string FaceAPIID { get; set; }
    }

    public class Plate : MissingModel
    {
        public string NumberPlate { get; set; }
    }

    public class Timestamp
    {
        public int ID { get; set; }
        public string DateAndTime { get; set; }

        public int MissingModelID { get; set; }
        public MissingModel MissingModel { get; set; }
    }
}
