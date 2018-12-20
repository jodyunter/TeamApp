using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamApp.Services.ViewModels.Views;

namespace TeamApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        // GET: api/League
        [HttpGet]
        public IEnumerable<LeagueViewModel> Get()
        {
            return null;
        }

        // GET: api/League/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/League
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/League/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
