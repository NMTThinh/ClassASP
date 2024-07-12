using AutoMapper;
using ClassASP.Entities;
using ClassASP.Interface.Repository;
using ClassASP.Interface.Service;
using ClassASP.Models;
using static ClassASP.Services.StudentService;

namespace ClassASP.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository studentRepository;
        private IMapper mapper;
        private readonly ILogger<IStudentService> logger;
        public StudentService(IStudentRepository studentRepository, IMapper mapper, ILogger<IStudentService> logger)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var res = await studentRepository.GetAllAsync();
            if (res == null)
            {
                logger.LogInformation($" No Student found");
            }
            return res;
        }
        public async Task<Student> GetStudentIdAsync(int id)
        {
            var res = await studentRepository.GetByIDAsync(id);
            if (res == null)
            {
                logger.LogInformation($"No Student with Id {id} found.");
            }
            return res;
        }
        public async Task CreateStudentAsync(CreateStudent request)
        {
            try
            {
                // DATA
                var dataAdd = mapper.Map<Student>(request);
                dataAdd.CreatedSt = DateTime.Now;
                // CREATE & SAVE
                await studentRepository.CreateAsync(dataAdd);
                await studentRepository.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating the student.");
            }
        }
        public async Task UpdateStudent(int id, UpdateStudent request)
        {
            try
            {
                // FINDED
                var dataTable = await studentRepository.GetByIDAsync(id);
                if (dataTable != null)
                {
                    var dataUpdate = mapper.Map(request, dataTable);
                    dataUpdate.UpdatedSt = DateTime.Now;
                    // UPDATE & SAVE
                    studentRepository.Update(dataUpdate);
                    await studentRepository.SaveChangeAsync();
                }
                else
                {
                    logger.LogInformation($" No Student found");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating the Student.");
            }
        }
        public async Task DeleteStudentAsync(int id)
        {
            try
            {
                // FINDED
                var data = await studentRepository.GetByIDAsync(id);
                if (data != null)
                {
                    // DELETE & SAVE
                    studentRepository.Delete(data);
                    await studentRepository.SaveChangeAsync();
                }
                else
                {
                    logger.LogInformation($"No Student found with the id {id}");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while remove the Student.");
            }
        }
    }
}
