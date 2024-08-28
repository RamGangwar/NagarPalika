using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class AssetSubCategoryVM
    {
        public int AssetSubCategoryId { get; set; }
        public string AssetSubCategoryName { get; set; }
        public string AssetCategoryName { get; set; }
        public int AssetCategoryId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string EmployeeName { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
