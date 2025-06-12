using Microsoft.AspNetCore.Mvc;
using MyRestApi.Models;

namespace MyRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private static readonly List<Person> _persons = new List<Person>
        {
            new Person { Id = 1, Name = "John", Surname = "Doe", Address = "123 Main St" },
            new Person { Id = 2, Name = "Jane", Surname = "Smith", Address = "456 Oak Ave" }
        };
        private static int _nextId = 3;

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return Ok(_persons);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = _persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            person.Id = _nextId++;
            _persons.Add(person);
            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Person person)
        {
            if (person == null || id != person.Id)
            {
                return BadRequest();
            }

            var existingPerson = _persons.FirstOrDefault(p => p.Id == id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            existingPerson.Name = person.Name;
            existingPerson.Surname = person.Surname;
            existingPerson.Address = person.Address;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            _persons.Remove(person);
            return NoContent();
        }
    }
}