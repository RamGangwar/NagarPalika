using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Entity
{
    [Table("Zones")]
    public class Zones:BaseEntity
    {
        [Key]
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string ZoneCode { get; set; }
        public int DistrictId { get; set; }
    }
}
