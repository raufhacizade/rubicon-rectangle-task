using Microsoft.EntityFrameworkCore;

namespace RubiconTask.Base.DataAccess.Interfaces
{
    public interface IUnitOfWork<TContext> : IUnitOfWorkBase, IDisposable where TContext : DbContext
    {
        TContext DbContext { get; }
    }
}
