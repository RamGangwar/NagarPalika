using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class TradeDocumentVM
    {
        public int TradeDocumentId { get; set; }
        public string TradeDocumentName { get; set; }
        public int SessionMasterId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string EmployeeName { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
