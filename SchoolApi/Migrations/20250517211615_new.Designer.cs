﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolApi.Models;

#nullable disable

namespace SchoolApi.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20250517211615_new")]
    partial class @new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolApi.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Sections")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schools");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Essoukri Najoua",
                            Name = "École Nationale d'Ingénieur de Sousse",
                            Rating = 3.5,
                            Sections = "Informatique, Mécatronique, Électronique",
                            WebSite = "http://www.eniso.rnu.tn/fr/"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Mr X",
                            Name = "ENIM",
                            Rating = 3.0,
                            Sections = "Textile, Mécanique, Électrique",
                            WebSite = "https://enim.rnu.tn/"
                        },
                        new
                        {
                            Id = 3,
                            Director = "M. Ben Ali",
                            Name = "ENSI",
                            Rating = 4.2000000000000002,
                            Sections = "Informatique, Génie Logiciel"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
