using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Entity
{
    [Table("MutationType")]
    public class MutationType : BaseEntity
    {
        [Key]
        public int MutationTypeId { get; set; }
        public string MutationTypeName { get; set; }
        public decimal MutationFee { get; set; }
    }
}
