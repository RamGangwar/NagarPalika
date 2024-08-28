using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Entity
{
    [Table("DiscountSlab")]
    public class DiscountSlab : BaseEntity
    {
        [Key]
        public int DiscountSlabId { get; set; }
        public string PropertyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Value { get; set; }
        public bool SkipCondition { get; set; }
    }
}
