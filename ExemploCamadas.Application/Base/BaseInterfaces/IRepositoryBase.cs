using System.Linq.Expressions;
using ExemploCamadas.Domain.Entities;

namespace ExemploCamadas.Application.Base.BaseInterfaces;

public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
{
    TEntity Create(TEntity model);

    void Update(TEntity model);

    void Delete(TEntity model, bool forcePhysicalDelete = false);

    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> where);

    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, object> includes);

    IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where);

    IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, object> includes);

    Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, object> includes);
    Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> where);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where);
}