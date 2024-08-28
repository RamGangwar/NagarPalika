using Dapper.Contrib.Extensions;
namespace NagarPalika.Domain.Entity
{
    [Table("Designation")]
    public class Designation:BaseEntity
    {
        [Key]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int DesignationLevel { get; set; }
    }
}
