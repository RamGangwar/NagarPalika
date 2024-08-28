using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Entity
{
    [Table("DisabilitySlab")]
    public class DisabilitySlab : BaseEntity
    {
        [Key]
        public int DisabilitySlabId { get; set; }
        public string PropertyType { get; set; }
        public decimal StartValue { get; set; }
        public decimal EndValue { get; set; }
        public decimal Value { get; set; }
    }
}
