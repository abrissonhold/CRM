using Aplication.Interfaces;
using Aplication.Response;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly ITaskStatusService _services;

        public TaskStatusController(ITaskStatusService services)
        {
            _services = services;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GenericResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return Ok(result);
        }
    }
}
