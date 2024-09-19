﻿using Aplication.Interfaces;
using Aplication.Request;
using Aplication.UseCase;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CRM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _services;

        public ClientController(IClientService services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _services.GetAll();
            return new JsonResult(result);
        }
        [HttpPost]
        [ProducesResponseType(typeof(JsonResult), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<ActionResult> CreateClient(ClientRequest client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiError { Message = "Invalid data" });
            }
            var result = await _services.CreateClient(client);
            return new JsonResult(result);
        }


    }        
    class ApiError : ModelStateDictionary
        {
            public string Message { get; set; }
        }
}
