using ValidationTask.Models;

namespace ValidationTask.Services
{
    public interface IEmployeeService
    {
        public List<Employee> GetAll();
        public Employee GetById(Guid id);
        public Guid Add(Employee employee);
    }
}
