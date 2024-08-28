using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("TradeSubCategory")]
    public class TradeSubCategory : BaseEntity
    {
        [Key]public int TradeSubCategoryId {get; set;}
public string TradeSubCategoryName {get; set;}
public int TradeCategoryId {get; set;}
public decimal Fees {get; set;}
public string TermAndCondition {get; set;}
public int SessionMasterId {get; set;}
}
}
