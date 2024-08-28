using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Entity
{
    [Table("RecieptBooks")]
    public class RecieptBooks : BaseEntity
    {
        [Key]
        public int RecieptBookId { get; set; }
        public string RecieptBook { get; set; }
        public string BookType { get; set; }
        public int StartSrNo { get; set; }
        public int EndSrNo { get; set; }
        public int AllowcatedTo { get; set; }
    }
}
