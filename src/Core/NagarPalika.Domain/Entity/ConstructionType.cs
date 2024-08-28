using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Entity
{
    [Table("ConstructionType")]
    public class ConstructionType : BaseEntity
    {
        [Key]
        public int ConstructionTypeId { get; set; }
        public string ConstructionTypeName { get; set; }
    }
}
