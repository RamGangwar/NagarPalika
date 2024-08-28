using Dapper.Contrib.Extensions;
namespace NagarPalika.Domain.Entity
{
    [Table("TenantSlab")]
    public class TenantSlab : BaseEntity
    {
        [Key]
        public int TenantSlabId { get; set; }
        public string PropertyType { get; set; }
        public decimal SlabStartValue { get; set; }
        public decimal SlabEndValue { get; set; }
        public decimal Value { get; set; }
    }
}