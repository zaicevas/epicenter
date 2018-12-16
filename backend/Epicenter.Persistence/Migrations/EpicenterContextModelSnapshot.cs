﻿// <auto-generated />
using System;
using Epicenter.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Epicenter.Persistence.Migrations
{
    [DbContext(typeof(EpicenterDbContext))]
    partial class EpicenterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Epicenter.Domain.Models.Abstract.MissingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("BaseImage");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("Reason");

                    b.HasKey("Id");

                    b.ToTable("MissingModels");

                    b.HasDiscriminator<string>("Discriminator").HasValue("MissingModel");
                });

            modelBuilder.Entity("Epicenter.Domain.Models.Timestamp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateAndTime");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<int>("MissingModelId");

                    b.Property<double>("Smile");

                    b.HasKey("Id");

                    b.HasIndex("MissingModelId");

                    b.ToTable("Timestamps");
                });

            modelBuilder.Entity("Epicenter.Domain.Models.Person", b =>
                {
                    b.HasBaseType("Epicenter.Domain.Models.Abstract.MissingModel");

                    b.Property<string>("FaceAPIId");

                    b.ToTable("Person");

                    b.HasDiscriminator().HasValue("Person");
                });

            modelBuilder.Entity("Epicenter.Domain.Models.Plate", b =>
                {
                    b.HasBaseType("Epicenter.Domain.Models.Abstract.MissingModel");

                    b.Property<string>("NumberPlate");

                    b.ToTable("Plate");

                    b.HasDiscriminator().HasValue("Plate");
                });

            modelBuilder.Entity("Epicenter.Domain.Models.Timestamp", b =>
                {
                    b.HasOne("Epicenter.Domain.Models.Abstract.MissingModel", "MissingModel")
                        .WithMany("Timestamps")
                        .HasForeignKey("MissingModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
