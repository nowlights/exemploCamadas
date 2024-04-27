using System.Linq.Expressions;
using ExemploCamadas.Application.Base.BaseInterfaces;
using ExemploCamadas.Infra.Data.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace ExemploCamadas.Infra.Data.Base;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    protected readonly AppDbContext _context;


    private DbSet<TEntity> DbSet => _context.Set<TEntity>();

    public RepositoryBase(AppDbContext context)
    {
        _context = context;
        _context.ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public IQueryable<TEntity> Query()
        => DbSet.AsNoTracking();

    public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where)
        => DbSet.AsNoTracking().Where(@where);

    public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, object> includes)
    {
        IQueryable<TEntity>? _query = DbSet;

        if (includes != null)
            _query = includes(_query) as IQueryable<TEntity>;

        return (_query ?? throw new InvalidOperationException()).AsNoTracking().Where(predicate).AsQueryable();
    }


    public async Task<TEntity?> FindAsync(Expression<Func<TEntity?, bool>> where)
        => await DbSet.AsNoTracking().FirstOrDefaultAsync(@where);

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where)
        => await DbSet.AsNoTracking().AnyAsync(where);

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity?, bool>> predicate,
        Func<IQueryable<TEntity>, object> includes)
    {
        IQueryable<TEntity>? _query = DbSet.AsNoTracking();

        if (includes != null)
            _query = includes(_query) as IQueryable<TEntity>;
        return await (_query ?? throw new InvalidOperationException()).AsNoTracking()
            .FirstOrDefaultAsync(predicate);
    }

    public async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> where)
        => await DbSet.AsNoTracking().Where(where).ToListAsync();

    public async Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, object> includes)
    {
        IQueryable<TEntity>? _query = DbSet;

        if (includes != null)
            if (_query != null)
                _query = includes(_query) as IQueryable<TEntity>;

        return await (_query ?? throw new InvalidOperationException()).AsNoTracking().Where(predicate)
            .ToListAsync();
    }


    public TEntity Create(TEntity model)
    {
        DbSet?.Add(model);
        return model;
    }


    public void Update(TEntity model)
    {
        DbSet.Attach(model);
        var entry = _context.Entry(model);
        entry.State = EntityState.Modified;
    }


    public void Delete(TEntity model, bool forcePhysicalDelete = false)
    {
        DbSet.Attach(model);
        var _entry = _context.Entry(model);
        _entry.State = EntityState.Deleted;
    }


    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }
}