using ClassASP.Interface.Service;
using ClassASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var Student = await studentService.GetAllAsync();
                if (Student == null || !Student.Any())
                {
                    return Ok(new { message = "No Student Items found" });
                }
                return Ok(new { message = "Successfully retrieved all  ", data = Student });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving all student", error = ex.Message });
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentIdAsync(int id)
        {
            try
            {
                var Student = await studentService.GetStudentIdAsync(id);
                if (Student == null)
                {
                    return NotFound(new { message = $"Student  with id {id} not found" });
                }
                return Ok(new { message = "Successfully retrieved all Student ", data = Student });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving all student it", error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync(CreateStudent request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await studentService.CreateStudentAsync(request);
                return Ok(new { message = "Student successfully created" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the crating Student", error = ex.Message });
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStudentAsync(int id, UpdateStudent request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Student = await studentService.GetStudentIdAsync(id);
                if (Student == null)
                {
                    return NotFound(new { message = $"Student Item  with id {id} not found" });
                }
                await studentService.UpdateStudent(id, request);
                return Ok(new { message = $" Student with id {id} successfully updated" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while updating student with id {id}", error = ex.Message });
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            try
            {
                var Student = await studentService.GetStudentIdAsync(id);
                if (Student == null)
                {
                    return NotFound(new { message = $"Student  with id {id} not found" });
                }
                await studentService.DeleteStudentAsync(id);
                return Ok(new { message = $"Student  with id {id} successfully deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while deleting Student  with id {id}", error = ex.Message });
            }
        }
    }
}
