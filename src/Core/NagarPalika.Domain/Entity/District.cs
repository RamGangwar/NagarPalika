using Dapper.Contrib.Extensions;

namespace NagarPalika.Domain.Entity
{
    [Table("District")]
    public class District : BaseEntity
    {
        [Key] 
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string DistrictCode { get; set; }
        public int StateId { get; set; }
    }
}
