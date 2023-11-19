using RubiconTask.Base.DataAccess.Interfaces;
using RubiconTask.Base.Models.Interfaces;
using RubiconTask.Base.Services.Interfaces;
using RubiconTask.Extensions;

namespace RubiconTask.Base.Services
{
  public class BaseService<TEntity, TUnitOfWork, TRepository> : ReadOnlyBaseService<TEntity, TUnitOfWork, TRepository>, IBaseService<TEntity> where TRepository : class, IRepository<TEntity> where TUnitOfWork : IUnitOfWorkBase where TEntity : IBaseEntity

  {
    public BaseService(TUnitOfWork unitOfWork, ILogger logger) : base(unitOfWork, logger)
    {
    }

    public async Task<int> Create(TEntity entity)
    {
      _logger.DebugMethodStart(nameof(Create));

      await _unitOfWork.Repository<TRepository>().Create(entity);
      await _unitOfWork.SaveChanges();

      _logger.DebugMethodEnd(nameof(Create));
      return _unitOfWork.Repository<TRepository>().GetPrimaryKeyValue(entity);
    }

    public virtual async Task Update(TEntity entity)
    {
      _logger.DebugMethodStart(nameof(Update));

      _unitOfWork.Repository<TRepository>().Update(entity);
      await _unitOfWork.SaveChanges();

      _logger.DebugMethodEnd(nameof(Update));
    }
    public virtual async Task Delete(TEntity entity)
    {
      _logger.DebugMethodStart(nameof(Delete));

      _unitOfWork.Repository<TRepository>().Delete(entity);
      await _unitOfWork.SaveChanges();

      _logger.DebugMethodEnd(nameof(Delete));
    }
  }
}
