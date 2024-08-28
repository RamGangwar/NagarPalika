using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("UserType")]
    public class UserType : BaseEntity
    {
        [Key]public int UserTypeId {get; set;}
public string UserTypeName {get; set;}
}
}
