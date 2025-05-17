using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Models
{
    
   
        public class SchoolDbContext : DbContext
        {
            public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
                : base(options)
            {
            }

            public DbSet<School> Schools { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<School>().HasData(
                    new School
                    {
                        Id = 1,
                        Name = "École Nationale d'Ingénieur de Sousse",
                        Sections = "Informatique, Mécatronique, Électronique",
                        Director = "Essoukri Najoua",
                        Rating = 3.5,
                        WebSite = "http://www.eniso.rnu.tn/fr/"
                    },
                    new School
                    {
                        Id = 2,
                        Name = "ENIM",
                        Sections = "Textile, Mécanique, Électrique",
                        Director = "Mr X",
                        Rating = 3,
                        WebSite = "https://enim.rnu.tn/"
                    },
                    new School
                    {
                        Id = 3,
                        Name = "ENSI",
                        Sections = "Informatique, Génie Logiciel",
                        Director = "M. Ben Ali",
                        Rating = 4.2
                        // Pas de WebSite, car c’est nullable
                    }
                );
            }
        }
    }
