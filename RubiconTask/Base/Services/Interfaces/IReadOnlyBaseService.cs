using RubiconTask.Base.Models.Interfaces;
using RubiconTask.ViewModels;
using System.Linq.Expressions;

namespace RubiconTask.Base.Services.Interfaces
{
  public interface IReadOnlyBaseService<T> where T : IBaseEntity
  {
    Task<T?> Get(int id, params Expression<Func<T, object>>[] includeProperties);

    Task<IEnumerable<T>> GetList(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties);

    Task<PaginationViewModel<T>> GetPaginatedList(int offset, int limit, Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties);
  }
}
