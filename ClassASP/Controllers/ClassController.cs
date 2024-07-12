using ClassASP.Interface.Service;
using ClassASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : Controller
    {
        private readonly IClassService classService;
        public ClassController(IClassService classService)
        {
            this.classService = classService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var Class = await classService.GetAllAsync();
                if (Class == null || !Class.Any())
                {
                    return Ok(new { message = "No Class Items found" });
                }
                return Ok(new { message = "Successfully retrieved all  ", data = Class });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving all class", error = ex.Message });
            }
        }
        [HttpGet("{classid:int}")]
        public async Task<IActionResult> GetClassIdAsync(int classid)
        {
            try
            {
                var Class = await classService.GetClassIdAsync(classid);
                if (Class == null)
                {
                    return NotFound(new { message = $"Class  with id {classid} not found" });
                }
                return Ok(new { message = "Successfully retrieved all Class ", data = Class });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving all class it", error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateClassAsync(CreateClass request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await classService.CreateClassAsync(request);
                return Ok(new { message = "Class successfully created" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the crating Class", error = ex.Message });
            }
        }
        [HttpPut("{classid:int}")]
        public async Task<IActionResult> UpdateClassAsync(int classid, UpdateClass request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Class = await classService.GetClassIdAsync(classid);
                if (Class == null)
                {
                    return NotFound(new { message = $"Class Item  with id {classid} not found" });
                }
                await classService.UpdateClass(classid, request);
                return Ok(new { message = $" Class with id {classid} successfully updated" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while updating class with id {classid}", error = ex.Message });
            }
        }
        [HttpDelete("{classid:int}")]
        public async Task<IActionResult> DeleteClassAsync(int classid)
        {
            try
            {
                var Class = await classService.GetClassIdAsync(classid);
                if (Class == null)
                {
                    return NotFound(new { message = $"Class  with id {classid} not found" });
                }
                await classService.DeleteClassAsync(classid);
                return Ok(new { message = $"Class  with id {classid} successfully deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while deleting Class  with id {classid}", error = ex.Message });
            }
        }
    }
}
