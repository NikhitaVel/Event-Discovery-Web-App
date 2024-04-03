using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/ValuesController.cs
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return EventRoster.allEvents;
        }

        // GET: api/ValuesController.cs/5
        [HttpGet("{id}", Name = "Get")]
        public Event Get(int id)
        {
            return EventRoster.allEvents[id];
        }

        // POST: api/ValuesController.cs
        [HttpPost]
        public void Post([FromBody] Event value)
        {
        }

        // PUT: api/ValuesController.cs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event value)
        {
        }

        // DELETE: api/ValuesController.cs/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
