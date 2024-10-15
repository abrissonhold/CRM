﻿using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InteractionTypeController : ControllerBase
    {
        private readonly IInteractionTypeService _services;

        public InteractionTypeController(IInteractionTypeService services)
        {
            _services = services;
        }
        [HttpGet]
        [ProducesResponseType(typeof(JsonResult), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return new JsonResult(result);
        }
    }
}
