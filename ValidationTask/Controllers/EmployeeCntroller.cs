using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ValidationTask.Models;
using ValidationTask.Services;

namespace ValidationTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCntroller : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeCntroller(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employee = _employeeService.GetAll();
            return Ok(employee);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var employee = _employeeService.GetById(id);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {

            if (!ModelState.IsValid)
            {
              
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

               
                throw new ValidationException("Validation Failed: " + string.Join("; ", errors));
            }
            var id = _employeeService.Add(employee);
            return Ok(id);
        }

    }
}
