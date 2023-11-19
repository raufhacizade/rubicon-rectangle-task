using Microsoft.EntityFrameworkCore;
using RubiconTask.Base.DataAccess;
using RubiconTask.Data;
using RubiconTask.DataAccess.Interfaces;
using RubiconTask.Models;
using System.Linq.Expressions;
using System;

namespace RubiconTask.DataAccess.Implementations
{
  public class RectangleRepository : Repository<Rectangle>, IRectangleRepository
  {
    public RectangleRepository(RubiconContext context, ILogger<RectangleRepository> logger) : base(context, logger)
    {
    }

    public async Task<IEnumerable<Rectangle>> Search(int? x1, int? y1, int? x2, int? y2, bool isStrick = true)
    {
      IQueryable<Rectangle> query = _context.Set<Rectangle>();
      query = query.Where(r => !r.IsDeleted);

      if (isStrick)
      {
        if (x1 is not null)
          query = query.Where(r => r.X1 == x1);
        if (y1 is not null)
          query = query.Where(r => r.Y1 == y1);
        if (x2 is not null)
          query = query.Where(r => r.X2 == x2);
        if (y2 is not null)
          query = query.Where(r => r.Y2 == x2);
      }
      else
        query = query.Where(r => r.X1 == x1 || r.Y1 == y1 || r.X2 == x2 || r.Y2 == y2);

      return await query.ToListAsync();
    }
  }
}
