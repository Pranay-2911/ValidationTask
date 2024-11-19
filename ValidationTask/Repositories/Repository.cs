
using Microsoft.EntityFrameworkCore;
using ValidationTask.Data;

namespace ValidationTask.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeContext _context;
        private readonly DbSet<T> _table;

        public Repository(EmployeeContext employeeContext)
        {
            _context = employeeContext;
            _table = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
           
        }

        public T Get(Guid id)
        {
            var entity = _table.Find(id);
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }
    }
}
