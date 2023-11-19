using RubiconTask.Base.Services;
using RubiconTask.DataAccess.Implementations;
using RubiconTask.DataAccess.Interfaces;
using RubiconTask.Models;
using RubiconTask.Services.Interfaces;
using System.Linq.Expressions;

namespace RubiconTask.Services.Implementations
{
  public class RectangleService : BaseService<Rectangle, IRubiconUnitOfWork, IRectangleRepository>, IRectangleService
  {
    private IRectangleRepository _rectangleRepository;
    public RectangleService(IRubiconUnitOfWork unitOfWork, ILogger<RectangleService> logger, IRectangleRepository rectangleRepository) : base(unitOfWork, logger)
    {
      _rectangleRepository = rectangleRepository;
    }

    public async Task<IEnumerable<Rectangle>> Search(int? x1, int? y1, int? x2, int? y2, bool isStrick = true)
    {
     
      var result = await _rectangleRepository.Search(x1, y1, x2, y2, isStrick);
      return result;
    }

  }
}

