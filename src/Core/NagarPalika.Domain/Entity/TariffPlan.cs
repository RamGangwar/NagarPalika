using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Entity
{
    [Table("TariffPlan")]
    public class TariffPlan : BaseEntity
    {
        [Key]
        public int TariffPlanId { get; set; }
        public string PropertyType { get; set; }
        public decimal ARV_NonAssessed { get; set; }
        public decimal ARV_Assessed { get; set; }
        public decimal HouseTax_LessThan { get; set; }
        public decimal HouseTax_MoreThan { get; set; }
        public decimal HouseTax_LessThan_ForNonAssessed { get; set; }
        public decimal HouseTax_MoreThan_ForNonAssessed { get; set; }
        public decimal WaterTax_LessThan { get; set; }
        public decimal WaterTax_MoreThan { get; set; }
        public decimal WaterTax_LessThan_ForNonAssessed { get; set; }
        public decimal WaterTax_MoreThan_ForNonAssessed { get; set; }
        public decimal SewerTax_LessThan { get; set; }
        public decimal SewerTax_MoreThan { get; set; }
        public decimal SewerTax_LessThan_ForNonAssessed { get; set; }
        public decimal SewerTax_MoreThan_ForNonAssessed { get; set; }
    }
}
