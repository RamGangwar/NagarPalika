using System.Text.Json.Serialization;

namespace NagarPalika.Domain.ViewModels
{
    public class ZonesVM
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string ZoneCode { get; set; }
        public string EmployeeName { get; set; }
        public string DistrictName { get; set; }
        public int DistrictId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
