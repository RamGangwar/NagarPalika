using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("RNLAllotment")]
    public class RNLAllotment : BaseEntity
    {
        [Key]public int RNLAllotmentId {get; set;}
public string AllottedTo {get; set;}
public string FatherName {get; set;}
public string ContactNo {get; set;}
public string FullAddress {get; set;}
public decimal Fees {get; set;}
public string FinancialYear {get; set;}
public DateTime AllotmentDate {get; set;}
public DateTime? PossessionDate {get; set;}
public string Attachment {get; set;}
public int RNLPropertyId {get; set;}
}
}
