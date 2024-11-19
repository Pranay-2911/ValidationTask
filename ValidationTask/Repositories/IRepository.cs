namespace ValidationTask.Repositories
{
    public interface IRepository<T>
    {
        public void Add(T entity);
        public IQueryable<T> GetAll();
        public T Get(Guid id);
    }
}
