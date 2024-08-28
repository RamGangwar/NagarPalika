using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class TradeSubCategoryVM
    {
        public int TradeSubCategoryId { get; set; }
        public string TradeSubCategoryName { get; set; }
        public int TradeCategoryId { get; set; }
        public decimal Fees { get; set; }
        public string TermAndCondition { get; set; }
        public int SessionMasterId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EmployeeName { get; set; }
        public string TradeCategoryName { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
