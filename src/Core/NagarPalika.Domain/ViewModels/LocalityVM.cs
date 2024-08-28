using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NagarPalika.Domain.ViewModels
{
    public class LocalityVM
    {
        public int LocalityId { get; set; }
        public string LocalityName { get; set; }
        public string LocalityCode { get; set; }
        public string WardName { get; set; }
        public string EmployeeName { get; set; }
        public int WardId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
