using RubiconTask.Base.DataAccess.Interfaces;
using RubiconTask.Data;

namespace RubiconTask.DataAccess.Interfaces
{
  public interface IRubiconUnitOfWork : IUnitOfWork<RubiconContext>
  {
    IRectangleRepository RectangleRepository { get; }
  }
}
