using Aplication.Interfaces;
using Aplication.Request;
using Aplication.Response;
using Aplication.UserCase;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClientResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateClient(ClientRequest client)
        {
            try
            {
                var result = await _service.CreateClient(client);
                return Ok(result);
            }
            catch (Exception e)
            {
                var apiError = new ApiError { Message = e.Message };
                return BadRequest(apiError);
            }
        }
    }
}
