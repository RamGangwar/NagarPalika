using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class FineCriteriaVM
    {
        public int FineCriteriaId { get; set; }
        public string PropertyType { get; set; }
        public decimal ARVThreshold { get; set; }
        public decimal HouseTax_LessThan { get; set; }
        public decimal HouseTax_MoreThan { get; set; }
        public decimal WaterTax_LessThan { get; set; }
        public decimal WaterTax_MoreThan { get; set; }
        public decimal SewerTax_LessThan { get; set; }
        public decimal SewerTax_MoreThan { get; set; }
        public bool IsActive { get; set; }
        public string EmployeeName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
