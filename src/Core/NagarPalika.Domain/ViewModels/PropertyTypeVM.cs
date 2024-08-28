using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class PropertyTypeVM
    {
        public int PropertyTypeId { get; set; }
        public string PropertyTypeName { get; set; }
        public string Grade { get; set; }
        public int CommercialFactor { get; set; }
        public string IconUrl { get; set; }
        public string EmployeeName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
