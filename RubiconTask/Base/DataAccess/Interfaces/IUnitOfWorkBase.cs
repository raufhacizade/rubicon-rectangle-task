namespace RubiconTask.Base.DataAccess.Interfaces
{
    public interface IUnitOfWorkBase
    {
        TSrv Repository<TSrv>() where TSrv : class;

        Task<int> SaveChanges();
    }
}
