using Dapper.Contrib.Extensions;
namespace NagarPalika.Domain.Entity
{
    [Table("Roles")]
    public class Roles:BaseEntity
    {
        [Key] 
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
