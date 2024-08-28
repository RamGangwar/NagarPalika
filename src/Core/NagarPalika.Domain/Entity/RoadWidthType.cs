using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Entity
{
    [Table("RoadWidthType")]
    public class RoadWidthType : BaseEntity
    {
        [Key]
        public int RoadWidthTypeId { get; set; }
        public string RoadWidthTypeName { get; set; }
    }
}
