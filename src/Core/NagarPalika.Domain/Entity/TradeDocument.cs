using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("TradeDocument")]
    public class TradeDocument : BaseEntity
    {
        [Key]public int TradeDocumentId {get; set;}
public string TradeDocumentName {get; set;}
public int SessionMasterId {get; set;}
}
}
