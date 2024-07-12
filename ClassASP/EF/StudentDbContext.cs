using ClassASP.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassASP.EF
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
