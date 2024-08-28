using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class RNLAllotmentVM
    {
        public int RNLAllotmentId { get; set; }
        public string AllottedTo { get; set; }
        public string FatherName { get; set; }
        public string ContactNo { get; set; }
        public string FullAddress { get; set; }
        public decimal Fees { get; set; }
        public string FinancialYear { get; set; }
        public DateTime AllotmentDate { get; set; }
        public DateTime? PossessionDate { get; set; }
        public string Attachment { get; set; }
        public int RNLPropertyId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EmployeeName { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
