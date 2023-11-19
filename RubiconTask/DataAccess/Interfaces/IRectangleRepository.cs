using RubiconTask.Base.DataAccess.Interfaces;
using RubiconTask.Models;

namespace RubiconTask.DataAccess.Interfaces
{
  public interface IRectangleRepository : IRepository<Rectangle>
  {
    public Task<IEnumerable<Rectangle>> Search(int? x1, int? y1, int? x2, int? y2, bool isStrick = true);
  }
}
