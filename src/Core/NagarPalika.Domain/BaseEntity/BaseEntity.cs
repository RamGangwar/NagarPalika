using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Entity
{
    public class BaseEntity : baseEnity
    {
        public int CreatedBy { get; set; } = 0;
        public DateTime? ModifyOn { get; set; }
        public int? ModifyBy { get; set; }
    }
    public class baseEnity
    {

        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
      
    }
}
