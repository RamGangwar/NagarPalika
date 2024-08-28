using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("Locality")]
    public class Locality : BaseEntity
    {
        [Key]
        public int LocalityId { get; set; }
        public string LocalityName { get; set; }
        public string LocalityCode { get; set; }
        public int WardId { get; set; }
    }
}
