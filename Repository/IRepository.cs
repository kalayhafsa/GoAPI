public interface IRepository<T>
{
    IQueryable<T> Table { get; }
    IQueryable<T> TableNoTracking { get; }
    T GetById(object id);
    T Insert(T entity);
    IEnumerable<T> Insert(IEnumerable<T> entities);
    T Update(T entity);
    IEnumerable<T> Update(IEnumerable<T> entities);
    bool Delete(T entity);
    bool Delete(IEnumerable<T> entities);
    IEnumerable<T> GetSql(string sql);
    Task<IEnumerable<T>> GetAll();
}