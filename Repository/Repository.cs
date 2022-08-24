using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly GoContext _context;
    private DbSet<T> _entities;

    public Repository(GoContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }
    public async Task<IEnumerable<T>> GetAll()
    {
        return await Entities.ToListAsync();
    }
    public async Task<T> GetById(object id)
    {
        return await Entities.FindAsync(id);
    }

    public T Insert(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        _entities.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public virtual IEnumerable<T> Insert(IEnumerable<T> entities)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        foreach (var entity in entities)
            Entities.Add(entity);

        _context.SaveChanges();
        return entities;
    }

    public T Update(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        var rs = _context.SaveChanges();
        return entity;
    }

    public virtual void Update(IEnumerable<T> entities)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        _context.SaveChanges();
    }

    public bool Delete(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));
        Entities.Remove(entity);
        var rs = _context.SaveChanges();
        return rs == 1 ? true : false;
    }

    public virtual bool Delete(IEnumerable<T> entities)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        foreach (var entity in entities)
            Entities.Remove(entity);
        var rs = _context.SaveChanges();
        return rs == 0 ? false : true;
    }

    public IEnumerable<T> GetSql(string sql)
    {
        return Entities.FromSqlRaw(sql);
    }

    T IRepository<T>.GetById(object id)
    {
        throw new NotImplementedException();
    }

    public virtual IQueryable<T> Table => Entities;

    public virtual IQueryable<T> TableNoTracking => Entities.AsNoTracking();

    protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());

}