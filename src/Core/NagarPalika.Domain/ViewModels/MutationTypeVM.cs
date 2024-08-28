using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class MutationTypeVM
    {
        public int MutationTypeId { get; set; }
        public string MutationTypeName { get; set; }
        public decimal MutationFee { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EmployeeName { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
