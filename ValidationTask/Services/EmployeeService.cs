using ValidationTask.Exceptions;
using ValidationTask.Models;
using ValidationTask.Repositories;

namespace ValidationTask.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Guid Add(Employee employee)
        {
            _employeeRepository.Add(employee);
            return employee.Id;
        }

        public List<Employee> GetAll()
        {
            var employees = _employeeRepository.GetAll().ToList();
            if (employees.Count == 0)
            {
                throw new EmployeeNotFoundException("Employee Does not Exist");
            }
            return employees;
        }

        public Employee GetById(Guid id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                throw new EmployeeNotFoundException("Employee Does not Exist");
            }
            return employee;
        }
    }
}
