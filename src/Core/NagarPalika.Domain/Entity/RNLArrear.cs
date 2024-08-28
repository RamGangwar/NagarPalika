using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("RNLArrear")]
    public class RNLArrear : BaseEntity
    {
        [Key]public int RNLArrearId {get; set;}
public string AllottedTo {get; set;}
public decimal ArrearAmount {get; set;}
public string Remark {get; set;}
public int RNLAllotmentId {get; set;}
}
}
