using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyRestService.Controllers
{
    [ApiController]
    [Route("persons")]
    public class PersonsController : ControllerBase
    {
        public class Person
        {
            public string Name { get; set; }
            public string Address { get; set; }
        }

        // Sample list of persons
        private static readonly List<Person> SamplePersons = new List<Person>
        {
            new Person { Name = "Alice Smith", Address = "123 Main St" },
            new Person { Name = "Bob Johnson", Address = "456 Oak Ave" },
            new Person { Name = "Charlie Brown", Address = "789 Pine Rd" }
        };

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return SamplePersons;
        }

        // Get a person by name (case-insensitive)
        [HttpGet("name")]
        public ActionResult<Person> GetByName(string name)
        {
            var person = SamplePersons
                .Find(p => p.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            if (person == null)
                return NotFound();
            return Ok(person);
        }
    }
}
