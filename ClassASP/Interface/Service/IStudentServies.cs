using ClassASP.Entities;
using ClassASP.Models;

namespace ClassASP.Interface.Service
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetStudentIdAsync(int id);
        Task CreateStudentAsync(CreateStudent request);
        Task UpdateStudent(int id, UpdateStudent request);
        Task DeleteStudentAsync(int id);
    }
}
