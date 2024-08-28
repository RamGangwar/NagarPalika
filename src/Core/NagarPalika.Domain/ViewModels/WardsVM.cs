using System.Text.Json.Serialization;

namespace NagarPalika.Domain.ViewModels
{
    public class WardsVM
    {
        public int WardId { get; set; }
        public string WardName { get; set; }
        public string ZoneName { get; set; }
        public string EmployeeName { get; set; }
        public int WardNo { get; set; }
        public int ZoneId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
