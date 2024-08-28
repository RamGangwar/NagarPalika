using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("TradeRegistration")]
    public class TradeRegistration : BaseEntity
    {
        [Key] public int TradeRegistrationId { get; set; }
        public string TradeCode { get; set; }
        public string ApplicationType { get; set; }
        public string OwnerName { get; set; }
        public string FatherName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Religion { get; set; }
        public string IdProofType { get; set; }
        public string IdProofNo { get; set; }
        public string Gender { get; set; }
        public string HouseNo { get; set; }
        public string TradeName { get; set; }
        public string TradeAddress { get; set; }
        public int ZoneId { get; set; }
        public int WardId { get; set; }
        public int LocalityId { get; set; }
        public int TradeCategoryId { get; set; }
        public int TradeSubCategoryId { get; set; }
        public DateTime? ARVEffectedDate { get; set; }
        public decimal Arrear { get; set; }
        public decimal ArrearFrom { get; set; }
        public decimal ArrearTill { get; set; }
        public int SessionMasterId { get; set; }
    }
}
