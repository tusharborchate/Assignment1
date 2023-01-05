using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment.Entities;
using Assignment1.Entities;
using System.IO;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Context _context;

        public EmployeesController(Context context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeViewModal employee)
        {
            Employee employee1 = new Employee();
            employee1.FirstName=employee.FirstName;
            employee1.LastName=employee.LastName;
            employee1.ContactNumber = employee.ContactNumber;
            employee1.Budget = employee.Budget;
            employee1.Email = employee.Email;
            foreach (var item in employee.Files)
            {
                string file = null;
                if (item.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        item.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                         file = Convert.ToBase64String(fileBytes);
                        // act on the Base64 data
                    }
                }
                employee1.UserFiles.Add(new UserFile { UserId = employee1.Id, Id = 0 ,File=file,FileName=item.FileName});
            }
            foreach (var item in employee.Technologies)
            {
                employee1.Technologies.Add(new UserTechnologies { UserID = employee1.Id, Id = 0 });
            }
            _context.Employees.Add(employee1);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
