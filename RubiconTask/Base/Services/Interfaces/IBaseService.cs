using RubiconTask.Base.Models.Interfaces;

namespace RubiconTask.Base.Services.Interfaces
{
    public interface IBaseService<T> : IReadOnlyBaseService<T> where T : IBaseEntity
    {
        Task Update(T entity);

        Task<int> Create(T entity);

        Task Delete(T entity);
    }
}
