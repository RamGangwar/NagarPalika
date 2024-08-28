using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class DepriciationSlabVM
    {
        public int DepriciationSlabId { get; set; }
        public string PropertyType { get; set; }
        public decimal StartValue { get; set; }
        public decimal EndValue { get; set; }
        public decimal Value { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EmployeeName { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
