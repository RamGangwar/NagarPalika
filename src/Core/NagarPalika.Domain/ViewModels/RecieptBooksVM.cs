using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class RecieptBooksVM
    {
        public int RecieptBookId { get; set; }
        public string RecieptBook { get; set; }
        public string BookType { get; set; }
        public int StartSrNo { get; set; }
        public int EndSrNo { get; set; }
        public int AllowcatedTo { get; set; }
        public bool IsActive { get; set; }
        public string EmployeeName { get; set; }
        public string AllowcatedEmployee { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
