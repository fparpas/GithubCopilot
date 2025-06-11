using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyRestService.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeesController : ControllerBase
    {
        public class Employee
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Address { get; set; }
            public string EmployeeType { get; set; }
        }

        // Sample list of employees
        private static readonly List<Employee> SampleEmployees = new List<Employee>
        {
            new Employee { Name = "Alice", Surname = "Smith", Address = "123 Main St", EmployeeType = "Manager" },
            new Employee { Name = "Bob", Surname = "Johnson", Address = "456 Oak Ave", EmployeeType = "Developer" },
            new Employee { Name = "Charlie", Surname = "Brown", Address = "789 Pine Rd", EmployeeType = "HR" }
        };

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return SampleEmployees;
        }

        // Get an employee by name and surname (case-insensitive)
        [HttpGet("search")]
        public ActionResult<Employee> GetByNameSurname(string name, string surname)
        {
            var employee = SampleEmployees.Find(e =>
                e.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase) &&
                e.Surname.Equals(surname, System.StringComparison.OrdinalIgnoreCase));
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        // Filter employees by employee type (case-insensitive)
        [HttpGet("bytype")]
        public ActionResult<IEnumerable<Employee>> GetByEmployeeType(string employeeType)
        {
            var filtered = SampleEmployees.FindAll(e =>
                e.EmployeeType.Equals(employeeType, System.StringComparison.OrdinalIgnoreCase));
            if (filtered == null || filtered.Count == 0)
                return NotFound();
            return Ok(filtered);
        }
    }
}
