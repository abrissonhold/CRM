using Aplication.Interfaces;
using Aplication.Request;
using Aplication.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _services;

        public ProjectController(IProjectService services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetProjects(string? name, int? campaignType, int? clientId, int offset = 0, int size = 10)
        {
            List<ProjectResponse> result = (List<ProjectResponse>)await _services.GetProjects(name, campaignType, clientId, offset, size);
            return new JsonResult(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<ActionResult> CreateProject(ProjectRequest project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiError { Message = "Invalid data" });
            }
            var existingProject = await _services.GetByName(project.ProjectName);
            if (existingProject != null)
            {
                return BadRequest(new ApiError { Message = "Project with the same name already exists" });
            }
            var result = await _services.CreateProject(project);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(JsonResult), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiError { Message = "Invalid data" });
            }
            var result = await _services.GetById(id);
            if (result == null)
            {
                return NotFound(new ApiError { Message = "Project not found" });
            }
            return new JsonResult(result);
        }

        [HttpPatch("{id}/interactions")]
        [ProducesResponseType(typeof(JsonResult), 201)]
        public async Task<IActionResult> AddInteraction(Guid id, InteractionRequest interaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiError { Message = "Invalid data" });
            }
            var result = await _services.AddInteraction(id, interaction);
            return new JsonResult(result);
        }

        [HttpPatch("{id}/tasks")]
        [ProducesResponseType(typeof(JsonResult), 201)]
        public async Task<IActionResult> AddTask(Guid id, TasksRequest task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiError { Message = "Invalid data" });
            }
            var result = await _services.AddTask(id, task);
            return new JsonResult(result);
        }

        [HttpPatch("{id}/tasks/{taskId}")]
        [ProducesResponseType(typeof(JsonResult), 201)]
        public async Task<IActionResult> UpdateTask(Guid id, Guid taskId, TasksRequest task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiError { Message = "Invalid data" });
            }

            var result = await _services.UpdateTask(id, taskId, task);
            if (result == null)
            {
                return NotFound(new ApiError { Message = "Task not found" });
            }

            return new JsonResult(result);
        }
    }
}
