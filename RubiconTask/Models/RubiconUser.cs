using Microsoft.AspNetCore.Identity;
using RubiconTask.Base.Models.Interfaces;

namespace RubiconTask.Models
{
    public class RubiconUser: IdentityUser, IBaseEntity, ITrackCreate
  {
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedOn { get; set; }
  }
}
