using Dapper.Contrib.Extensions;
namespace NagarPalika.Domain.Entity
{
    [Table("Department")]
    public class Department:BaseEntity
    {
        [Key] 
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
