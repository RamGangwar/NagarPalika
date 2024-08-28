using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;

namespace NagarPalika.Domain.ViewModels
{
    public class RolesVM
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string EmployeeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
