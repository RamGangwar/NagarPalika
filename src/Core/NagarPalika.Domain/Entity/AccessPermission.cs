using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("AccessPermission")]
    public class AccessPermission : baseEnity
    {
        [Key]
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanView { get; set; }
        public int SessionMasterId { get; set; }
        public int CreatedBy { get; set; }
    }
}
