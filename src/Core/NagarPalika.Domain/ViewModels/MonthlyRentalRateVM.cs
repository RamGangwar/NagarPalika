using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class MonthlyRentalRateVM
    {
        public int MonthlyRentalRateId { get; set; }
        public int WardId { get; set; }
        public string WardName { get; set; }
        public int LocalityId { get; set; }
        public string LocalityName { get; set; }
        public int RaodWidthTypeId { get; set; }
        public string RoadWidthTypeName { get; set; }
        public int ConstructionTypeId { get; set; }
        public string ConstructionTypeName { get; set; }
        public decimal ConstructedAreaRate { get; set; }
        public decimal EmptyAreaRate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string EmployeeName { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
