using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class RoadWidthTypeVM
    {
        public int RoadWidthTypeId { get; set; }
        public string RoadWidthTypeName { get; set; }
        public string EmployeeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
