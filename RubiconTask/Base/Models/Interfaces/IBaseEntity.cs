using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RubiconTask.Base.Models.Interfaces
{
    public interface IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
