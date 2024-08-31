using Microsoft.AspNetCore.Http.HttpResults;
using CRUDindotNet.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CRUDindotNet.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase //without controller base ok and not found was not working 
    {
        private readonly AppDbContext DBcontext;

        public EmployeesController(AppDbContext context)
        {
            DBcontext = context;
        }

        // GET: api/Employees
        [HttpGet]
        public ActionResult<Employee> GetEmployee()
        {
            // Fetch the employee from the database using the context
            var employee = DBcontext.Employee.ToList();

            // Check if the employee was found
            if (employee == null)
            {
                // Return a 404 Not Found response if the employee doesn't exist
                return NotFound();
            }

            // Return a 200 OK response with the employee data
            return Ok(employee);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            // Fetch the employee from the database using the context
            var employee = DBcontext.Employee.Find(id);

            // Check if the employee was found
            if (employee == null)
            {
                // Return a 404 Not Found response if the employee doesn't exist
                return NotFound();
            }

            // Return a 200 OK response with the employee data
            return Ok(employee);
        }

        // POST: api/Employees
        [HttpPost]
        public ActionResult<Employee> PostEmployee(Employee employee)
        {
            // Add the new employee to the database
            DBcontext.Employee.Add(employee);
            DBcontext.SaveChanges();

            // Return a 201 Created response with the employee data
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.ID }, employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public ActionResult PutEmployee(int id, Employee employee)
        {
            // Check if the provided ID matches the employee ID
            if (id != employee.ID)
            {
                return BadRequest();
            }

            // Update the employee in the database
            DBcontext.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
           DBcontext.SaveChanges();

            // Return a 204 No Content response
            return NoContent();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            // Find the employee in the database
            var employee =DBcontext.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Remove the employee from the database
            DBcontext.Employee.Remove(employee);
            DBcontext.SaveChanges();

            // Return a 204 No Content response
            return NoContent();
        }

    }
}
