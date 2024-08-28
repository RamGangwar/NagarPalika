using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class SessionMasterVM
    {
        public int SessionMasterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SessionName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
