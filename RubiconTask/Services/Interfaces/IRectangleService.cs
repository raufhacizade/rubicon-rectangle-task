using RubiconTask.Base.Services.Interfaces;
using RubiconTask.Models;

namespace RubiconTask.Services.Interfaces
{
  public interface IRectangleService : IBaseService<Rectangle>
  {
    public Task<IEnumerable<Rectangle>> Search(int? x1, int? y1, int? x2, int? y2, bool isStrick = true);
  }
}
