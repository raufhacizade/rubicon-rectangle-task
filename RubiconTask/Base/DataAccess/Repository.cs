using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using RubiconTask.ViewModels;
using RubiconTask.Base.Models.Interfaces;
using RubiconTask.Base.DataAccess.Interfaces;

namespace RubiconTask.Base.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        protected DbContext _context;
        protected readonly ILogger _logger;
        public Repository(DbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async virtual Task<T?> Get(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity is IBaseEntity baseEntity)
            {
                if (baseEntity.IsDeleted)
                {
                    return null;
                }
            }

            return entity;
        }

        public virtual async Task<T?> Get(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query;

            query = _context.Set<T>();

            if (includeProperties == null || includeProperties.Length <= 0)
                return await query.FirstOrDefaultAsync(predicate);

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                if (includeProperty != null)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetList(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                if (includeProperty != null)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (predicate == null)
                return await query.ToListAsync();
            else
                return await query.Where(predicate).ToListAsync();
        }

        public async Task<PaginationViewModel<T>> GetPaginatedList(int offset, int limit, Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            int totalCount;
            IEnumerable<T> data;
            IQueryable<T> query = _context.Set<T>();


            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                if (includeProperty != null)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (predicate != null)
                query = query.Where(predicate);
            totalCount = await query.CountAsync();
            data = await query.Skip(offset).Take(limit).ToListAsync();

            return new PaginationViewModel<T>
            {
                Offset = offset,
                Limit = limit,
                TotalCount = totalCount,
                Data = data
            };
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
                Delete(entity);
        }

        public int GetPrimaryKeyValue(T entity)
        {
            IEntityType? entityType = _context.Model.FindEntityType(typeof(T));

            if (entityType == null)
                throw new Exception(
                  $"This entity is not the part of the model! Entity: {typeof(T).Name}!");

            string? keyName = entityType.FindPrimaryKey()?.Properties?.Select(x => x.Name).Single();

            if (string.IsNullOrEmpty(keyName))
                throw new Exception(
                  $"The entity doesn't have primary key, or its primary key is a complex key! Entity: {typeof(T).Name}!");

            PropertyInfo? propInfo = typeof(T).GetProperty(keyName);

            if (propInfo == null)
                throw new Exception($"The primary key column not found! Entity: {typeof(T).Name}, field: {keyName}!");

            return (int)propInfo.GetValue(entity, null);
        }
    }
}
