using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MyRestService.Controllers
{
    [ApiController]
    [Route("addresses")]
    public class AddressController : ControllerBase
    {
        public class Address
        {
            public int Id { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
        }

        // Sample list of addresses
        private static readonly List<Address> SampleAddresses = new List<Address>
        {
            new Address { Id = 1, Street = "123 Main St", City = "New York", State = "NY", PostalCode = "10001", Country = "USA" },
            new Address { Id = 2, Street = "456 Oak Ave", City = "Los Angeles", State = "CA", PostalCode = "90210", Country = "USA" },
            new Address { Id = 3, Street = "789 Pine Rd", City = "Chicago", State = "IL", PostalCode = "60601", Country = "USA" }
        };

        private static int nextId = 4;

        // GET: Get all addresses
        [HttpGet]
        public IEnumerable<Address> Get()
        {
            return SampleAddresses;
        }

        // GET: Get address by ID
        [HttpGet("{id}")]
        public ActionResult<Address> GetById(int id)
        {
            var address = SampleAddresses.Find(a => a.Id == id);
            if (address == null)
                return NotFound();
            return Ok(address);
        }

        // GET: Search addresses by city (case-insensitive)
        [HttpGet("city")]
        public ActionResult<IEnumerable<Address>> GetByCity(string city)
        {
            var filtered = SampleAddresses.FindAll(a =>
                a.City.Equals(city, System.StringComparison.OrdinalIgnoreCase));
            if (filtered == null || filtered.Count == 0)
                return NotFound();
            return Ok(filtered);
        }

        // POST: Create a new address
        [HttpPost]
        public ActionResult<Address> Create([FromBody] Address address)
        {
            if (address == null)
                return BadRequest();

            address.Id = nextId++;
            SampleAddresses.Add(address);
            return CreatedAtAction(nameof(GetById), new { id = address.Id }, address);
        }

        // PUT: Update an existing address
        [HttpPut("{id}")]
        public ActionResult<Address> Update(int id, [FromBody] Address address)
        {
            if (address == null)
                return BadRequest();

            var existingAddress = SampleAddresses.Find(a => a.Id == id);
            if (existingAddress == null)
                return NotFound();

            existingAddress.Street = address.Street;
            existingAddress.City = address.City;
            existingAddress.State = address.State;
            existingAddress.PostalCode = address.PostalCode;
            existingAddress.Country = address.Country;

            return Ok(existingAddress);
        }

        // DELETE: Delete an address
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var address = SampleAddresses.Find(a => a.Id == id);
            if (address == null)
                return NotFound();

            SampleAddresses.Remove(address);
            return NoContent();
        }
    }
}