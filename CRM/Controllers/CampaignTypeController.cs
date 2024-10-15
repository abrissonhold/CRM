using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CampaignTypeController : ControllerBase
    {
        private readonly ICampaignTypeService _services;

        public CampaignTypeController(ICampaignTypeService services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetCampaignTypes()
        {
            var result = await _services.GetAll();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}