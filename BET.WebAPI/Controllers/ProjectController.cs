
using BET.Domain.BO;
using Microsoft.AspNetCore.Authorization;

namespace BET.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = new Response<IEnumerable<Project>>();
            response.Data = await _projectService.GetAllProjectAsync();
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(Project project)
        {
            var response = new Response<Guid>();
            response.Data = await _projectService.AddProjectAsync(project);
            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = new Response<Project>();
            response.Data = await _projectService.GetByIdProjectAsync(id);
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new Response<string>();
            await _projectService.DeleteProjectAsync(id);
            response.Data = "Deleted Successfully";
            return Ok(response);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Project project)
        {
            var response = new Response<string>();
            await _projectService.UpdateProjectAsync(project);
            response.Data = "Updated Successfully";
            return Ok(response);
        }

        [HttpGet("getAllDetails")]
        public async Task<IActionResult> GetAllDetails()
        {
            var response = new Response<IEnumerable<ProjectBO>>();
            response.Data = await _projectService.GetAllDetails();
            return Ok(response);
        }
    }
}
