using RubiconTask.Base.DataAccess.Interfaces;
using RubiconTask.Base.Models.Interfaces;
using RubiconTask.Base.Services.Interfaces;
using RubiconTask.Extensions;
using RubiconTask.ViewModels;
using System.Linq.Expressions;

namespace RubiconTask.Base.Services
{
    public class ReadOnlyBaseService<TEntity, TUnitOfWork, TRepository> : IReadOnlyBaseService<TEntity> where TRepository : class, IRepository<TEntity> where TUnitOfWork : IUnitOfWorkBase where TEntity : IBaseEntity
    {
        protected readonly Guid? _correlationId;
        protected readonly TUnitOfWork _unitOfWork;
        protected readonly ILogger _logger;

        public ReadOnlyBaseService(TUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public virtual async Task<TEntity?> Get(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            _logger.DebugMethodStart(nameof(Get));

            TEntity entity = await _unitOfWork.Repository<TRepository>().Get(x => x.Id == id, includeProperties);

            _logger.DebugMethodEnd(nameof(Get));
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            _logger.DebugMethodStart(nameof(GetList));

            IEnumerable<TEntity> entities = await _unitOfWork.Repository<TRepository>().GetList(predicate, includeProperties);

            _logger.DebugMethodEnd(nameof(GetList));
            return entities;
        }

        public async Task<PaginationViewModel<TEntity>> GetPaginatedList(int offset, int limit, Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            _logger.DebugMethodStart(nameof(GetPaginatedList));

            PaginationViewModel<TEntity> entities = await _unitOfWork.Repository<TRepository>().GetPaginatedList(offset, limit, predicate, includeProperties);

            _logger.DebugMethodEnd(nameof(GetPaginatedList));
            return entities;
        }
    }
}
