using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NicksSchoolDiary.Domain.Models;
namespace NicksSchoolDiary.DAL.DataContext
{
    public class NicksSchoolDiaryDbContext: DbContext
    {
        public NicksSchoolDiaryDbContext(DbContextOptions<NicksSchoolDiaryDbContext> options) : base(options)
        {
        }
        public DbSet<StudentClass> StudentClasses { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentClass>().ToTable("StudentClass");
            modelBuilder.Entity<Student>().ToTable("Student");


          


            modelBuilder.Entity<StudentClass>().HasData(new StudentClass() { Id = 1, Name = "1A" },
                new StudentClass() { Id = 2, Name = "1B" },
                new StudentClass() { Id = 3, Name = "2A" },
                new StudentClass() { Id = 4, Name = "2B" },
                new StudentClass() { Id = 5, Name = "3A" },
                new StudentClass() { Id = 6, Name = "3B" },
                new StudentClass() { Id = 7, Name = "4A" },
                new StudentClass() { Id = 8, Name = "4B" },
                new StudentClass() { Id = 9, Name = "5A" }
                );
        }
    }
}
