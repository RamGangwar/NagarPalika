using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Entity
{
    [Table("MonthlyRentalRate")]
    public class MonthlyRentalRate : BaseEntity
    {
        [Key]
        public int MonthlyRentalRateId { get; set; }
        public int WardId { get; set; }
        public int LocalityId { get; set; }
        public int RaodWidthTypeId { get; set; }
        public int ConstructionTypeId { get; set; }
        public decimal ConstructedAreaRate { get; set; }
        public decimal EmptyAreaRate { get; set; }
    }
}
