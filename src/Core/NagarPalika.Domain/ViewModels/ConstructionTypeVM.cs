using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class ConstructionTypeVM
    {
        public int ConstructionTypeId { get; set; }
        public string ConstructionTypeName { get; set; }
        public string EmployeeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
