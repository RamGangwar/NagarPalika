using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class DistrictVM
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string DistrictCode { get; set; }
        public string EmployeeName { get; set; }
        public int StateId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
