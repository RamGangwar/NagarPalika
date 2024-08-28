using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class AccessPermissionVM
    {
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanView { get; set; }
        public int SessionMasterId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
