using ClassASP.EF;
using ClassASP.Entities;
using ClassASP.Infrastructure;
using ClassASP.Interface.Repository;

namespace ClassASP.Repository
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(ClassDbContext context) : base(context)
        {
        }
    }
}
