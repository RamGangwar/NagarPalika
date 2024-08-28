using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("TradeCategory")]
    public class TradeCategory : BaseEntity
    {
        [Key]public int TradeCategoryId {get; set;}
public string TradeCategoryName {get; set;}
public string TermAndCondition {get; set;}
public int SessionMasterId {get; set;}
}
}
