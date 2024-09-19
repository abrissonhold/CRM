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

        /*[HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return new JsonResult(result);
        }*/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetProjects(string? name, int? campaignType, int? clientId, int offset = 0, int size = 10)
        {
            List<ProjectResponse> result = (List<ProjectResponse>)await _services.GetProjects(name, campaignType, clientId, offset, size);
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpPost]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<ActionResult> CreateProject(ProjectRequest project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiError { Message = "Invalid data" });
            }
            var result = await _services.CreateProject(project, _services.GetProject());
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
            return new JsonResult(result);
        }
    }
}
