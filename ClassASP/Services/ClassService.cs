using AutoMapper;
using ClassASP.Entities;
using ClassASP.Interface.Repository;
using ClassASP.Interface.Service;
using ClassASP.Models;
using static ClassASP.Services.ClassService;

namespace ClassASP.Services
{
    public class ClassService : IClassService
    {
        private IClassRepository classRepository;
        private IMapper mapper;
        private readonly ILogger<IClassService> logger;
        public ClassService(IClassRepository classRepository, IMapper mapper, ILogger<IClassService> logger)
        {
            this.classRepository = classRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            var res = await classRepository.GetAllAsync();
            if (res == null)
            {
                logger.LogInformation($" No Class found");
            }
            return res;
        }
        public async Task<Class> GetClassIdAsync(int classid)
        {
            var res = await classRepository.GetByIDAsync(classid);
            if (res == null)
            {
                logger.LogInformation($"No Class with Id {classid} found.");
            }
            return res;
        }
        public async Task CreateClassAsync(CreateClass request)
        {
            try
            {
                // DATA
                var dataAdd = mapper.Map<Class>(request);
                dataAdd.CreatedCl = DateTime.Now;
                // CREATE & SAVE
                await classRepository.CreateAsync(dataAdd);
                await classRepository.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating the class.");
            }
        }
        public async Task UpdateClass(int classid, UpdateClass request)
        {
            try
            {
                // FINDED
                var dataTable = await classRepository.GetByIDAsync(classid);
                if (dataTable != null)
                {
                    var dataUpdate = mapper.Map(request, dataTable);
                    dataUpdate.UpdatedCl = DateTime.Now;
                    // UPDATE & SAVE
                    classRepository.Update(dataUpdate);
                    await classRepository.SaveChangeAsync();
                }
                else
                {
                    logger.LogInformation($" No Class found");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating the Class.");
            }
        }
        public async Task DeleteClassAsync(int classid)
        {
            try
            {
                // FINDED
                var data = await classRepository.GetByIDAsync(classid);
                if (data != null)
                {
                    // DELETE & SAVE
                    classRepository.Delete(data);
                    await classRepository.SaveChangeAsync();
                }
                else
                {
                    logger.LogInformation($"No Class found with the classid {classid}");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while remove the Class.");
            }
        }
    }
}
