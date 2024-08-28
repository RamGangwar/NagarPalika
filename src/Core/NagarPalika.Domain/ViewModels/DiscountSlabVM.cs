using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class DiscountSlabVM
    {
        public int DiscountSlabId { get; set; }
        public string PropertyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Value { get; set; }
        public bool SkipCondition { get; set; }
        public string EmployeeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
