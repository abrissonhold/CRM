using Infraestructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/v1/ [controller]")]
    [ApiController]
    public class CampaignTypeController : ControllerBase
    {
        private readonly AppDbContext _context;
        // GET: api/<CampaignTypeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CampaignTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CampaignTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CampaignTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CampaignTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
