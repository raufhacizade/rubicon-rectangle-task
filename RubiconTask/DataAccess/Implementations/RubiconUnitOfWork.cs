using RubiconTask.Base.DataAccess;
using RubiconTask.Data;
using RubiconTask.DataAccess.Interfaces;

namespace RubiconTask.DataAccess.Implementations
{
  public class RubiconUnitOfWork : UnitOfWork<RubiconContext>, IRubiconUnitOfWork
  {
    public RubiconUnitOfWork(RubiconContext context, IServiceProvider serviceProvider) : base(context, serviceProvider)
    {
    }

    public IRectangleRepository RectangleRepository => Repository<IRectangleRepository>();
  }
}
