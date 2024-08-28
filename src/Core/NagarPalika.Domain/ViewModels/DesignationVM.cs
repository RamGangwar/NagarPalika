using System.Text.Json.Serialization;

namespace NagarPalika.Domain.ViewModels
{
    public class DesignationVM
    {
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int DesignationLevel { get; set; }
        public bool IsActive { get; set; }
        public string EmployeeName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
