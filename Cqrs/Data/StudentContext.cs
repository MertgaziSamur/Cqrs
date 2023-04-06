using Microsoft.EntityFrameworkCore;

namespace Cqrs.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student()
                {
                    Name = "Mert Gazi",
                    Surname = "Samur",
                    Age = 21,
                    Id = 1
                },
                new Student()
                {
                    Name = "Merve",
                    Surname = "Boğılmaz",
                    Age = 27,
                    Id = 2
                }
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
