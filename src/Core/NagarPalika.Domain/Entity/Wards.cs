using Dapper.Contrib.Extensions;
namespace NagarPalika.Domain.Entity
{
    [Table("Wards")]
    public class Wards:BaseEntity
    {
        [Key]
        public int WardId { get; set; }
        public string WardName { get; set; }
        public int WardNo { get; set; }
        public int ZoneId { get; set; }
    }
}
