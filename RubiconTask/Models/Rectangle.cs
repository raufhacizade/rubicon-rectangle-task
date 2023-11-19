using RubiconTask.Base.Models.Interfaces;

namespace RubiconTask.Models
{
  public class Rectangle : IBaseEntity, ITrackCreate
  {
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedOn { get; set; }
    public int X1 { get; set; }
    public int Y1 { get; set; }
    public int X2 { get; set; }
    public int Y2 { get; set; }
  }
}
