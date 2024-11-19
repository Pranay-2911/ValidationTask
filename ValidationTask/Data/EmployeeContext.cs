using Microsoft.EntityFrameworkCore;
using ValidationTask.Models;

namespace ValidationTask.Data
{
    public class EmployeeContext :DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
            
        }
    }
}
