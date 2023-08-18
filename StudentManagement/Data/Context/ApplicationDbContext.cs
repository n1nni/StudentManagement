
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.Entity;

namespace StudentManagement.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }

        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfStudentDB;Trusted_Connection=True;");
        }

        
    }
}
