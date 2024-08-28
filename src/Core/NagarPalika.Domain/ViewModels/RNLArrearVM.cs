using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class RNLArrearVM
    {
        public int RNLArrearId { get; set; }
        public string AllottedTo { get; set; }
        public decimal ArrearAmount { get; set; }
        public string Remark { get; set; }
        public int RNLAllotmentId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EmployeeName { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
