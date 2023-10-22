namespace IRDbApi.Repositories
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public void Add(T entity);
        public void UpdateById(int id, T entity);
        public void DeleteById(int id);
        public T? GetById(int id);
    }
}
