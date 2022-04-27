using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Linq.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {

        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=SchoolDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, Name = "Mr. Larsson" },
                new Teacher { Id = 2, Name = "Mrs. Eriksson" },
                new Teacher { Id = 3, Name = "Ms. Filipsson" }
                );
            modelBuilder.Entity<Course>().HasData(
                new { Id = 1, Name = "Engelska 7", TeacherId = 2 },
                new { Id = 2, Name = "Matematik 3B", TeacherId = 3 },
                new { Id = 3, Name = "Samhällskunskap 1A", TeacherId = 1 }
                );
            modelBuilder.Entity<Student>().HasData(
                new { Id = 1, Name = "Johanna Simonsson", ClassId = 1 },
                new { Id = 2, Name = "Darya Asaad", ClassId = 1 }, 
                new { Id = 3, Name = "Philippos Halkias", ClassId = 2 },
                new { Id = 4, Name = "Gina Digorno", ClassId = 2 }
                );
            modelBuilder.Entity<Class>().HasData(
                new { Id = 1, Name = "SA13B" },
                new { Id = 2, Name = "EK12A" }
                );
            modelBuilder
                .Entity<Class>()
                .HasMany(c => c.Courses)
                .WithMany(c => c.Classes)
                .UsingEntity(j => j.HasData(
                    new { ClassesId = 1, CoursesId = 3 },
                    new { ClassesId = 2, CoursesId = 3 },
                    new { ClassesId = 1, CoursesId = 1 },
                    new { ClassesId = 2, CoursesId = 2 }
                     ));
        }
    }
}
