using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NagarPalika.Domain.ViewModels
{
    public class OrganizationVM
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public string OrgCode { get; set; }
        public string LandLineNo { get; set; }
        public string MobileNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PinCode { get; set; }
        public string Email { get; set; }
        public string ULBType { get; set; }
        public string GSTNo { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string OrgLogo { get; set; }
        public string ShortName { get; set; }
        public bool IsHouseTax { get; set; }
        public bool IsWaterTax { get; set; }
        public bool IsSewerTax { get; set; }
        public int ARVFormulaId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public int TotalRecord { get; set; }
    }
}
