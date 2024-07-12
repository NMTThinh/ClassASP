using ClassASP.EF;
using ClassASP.Entities;
using ClassASP.Infrastructure;
using ClassASP.Interface.Repository;

namespace ClassASP.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudentDbContext context) : base(context)
        {
        }
    }
}
