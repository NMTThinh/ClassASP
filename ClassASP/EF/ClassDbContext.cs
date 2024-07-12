using ClassASP.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassASP.EF
{
    public class ClassDbContext : DbContext
    {
        public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options)
        {
        }
        public DbSet<Class> Classs { get; set; }
    }
}
