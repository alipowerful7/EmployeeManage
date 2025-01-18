using EmployeeManageApi.Models.DbContext;
using EmployeeManageApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManageApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok(await _context.Employees.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            emp.Name = employee.Name;
            emp.LastName = employee.LastName;
            emp.Phone = employee.Phone;
            emp.Email = employee.Email;
            emp.Salary = employee.Salary;
            _context.Employees.Update(emp);
            await _context.SaveChangesAsync();
            return Ok(emp);
        }
        [HttpGet("{searchString}")]
        public IActionResult SearchEmployee(string? searchString)
        {
            searchString = searchString!.ToLower();
            var employees = _context.Employees.Where(e => e.Name!.ToLower().Contains(searchString) || e.LastName!.ToLower().Contains(searchString) || e.Email!.ToLower().Contains(searchString) || e.Phone!.Contains(searchString));
            return Ok(employees);
        }
    }
}
