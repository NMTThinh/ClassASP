using ClassASP.Entities;
using ClassASP.Models;

namespace ClassASP.Interface.Service
{
    public interface IClassService
    {
        Task<IEnumerable<Class>> GetAllAsync();
        Task<Class> GetClassIdAsync(int id);
        Task CreateClassAsync(CreateClass request);
        Task UpdateClass(int id, UpdateClass request);
        Task DeleteClassAsync(int id);
    }
}
