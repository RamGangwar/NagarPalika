using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class TradeCategoryVM
    {
        public int TradeCategoryId { get; set; }
        public string TradeCategoryName { get; set; }
        public string TermAndCondition { get; set; }
        public int SessionMasterId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string EmployeeName { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
