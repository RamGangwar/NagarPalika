using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Entity
{
    [Table("PropertyType")]
    public class PropertyType : BaseEntity
    {
        [Key]
        public int PropertyTypeId { get; set; }
        public string PropertyTypeName { get; set; }
        public string Grade { get; set; }
        public int CommercialFactor { get; set; }
        public string IconUrl { get; set; }
    }
}
