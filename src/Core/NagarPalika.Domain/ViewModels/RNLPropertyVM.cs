using System.Text.Json.Serialization;
namespace NagarPalika.Domain.ViewModels
{
    public class RNLPropertyVM
    {
        public int RNLPropertyId { get; set; }
        public string RNLPropertyName { get; set; }
        public string RNLPropertyNo { get; set; }
        public decimal Fees { get; set; }
        public string PaymentType { get; set; }
        public decimal CoveredArea { get; set; }
        public decimal EmptyArea { get; set; }
        public decimal TotalArea { get; set; }
        public DateTime? EstablishedDate { get; set; }
        public string Remarks { get; set; }
        public int ZoneId { get; set; }
        public int WardId { get; set; }
        public int LocalityId { get; set; }
        public string PTINCode { get; set; }
        public int AssetCategoryId { get; set; }
        public int AssetSubCategoryId { get; set; }
        public string Floor { get; set; }
        public int PosessonModeId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
