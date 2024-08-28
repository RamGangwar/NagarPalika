using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class AssetCategoryVM
    {
        public int AssetCategoryId { get; set; }
        public string AssetCategoryName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EmployeeName { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
