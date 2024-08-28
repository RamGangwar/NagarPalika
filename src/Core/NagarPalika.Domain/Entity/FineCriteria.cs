using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Entity
{
    [Table("FineCriteria")]
    public class FineCriteria : BaseEntity
    {
        [Key]
        public int FineCriteriaId { get; set; }
        public string PropertyType { get; set; }
        public decimal ARVThreshold { get; set; }
        public decimal HouseTax_LessThan { get; set; }
        public decimal HouseTax_MoreThan { get; set; }
        public decimal WaterTax_LessThan { get; set; }
        public decimal WaterTax_MoreThan { get; set; }
        public decimal SewerTax_LessThan { get; set; }
        public decimal SewerTax_MoreThan { get; set; }
    }
}
