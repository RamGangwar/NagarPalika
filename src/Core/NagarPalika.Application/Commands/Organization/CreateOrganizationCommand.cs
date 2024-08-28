using MediatR;
using Microsoft.AspNetCore.Http;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace NagarPalika.Application.Commands.Organization
{
    public class CreateOrganizationCommand : IRequest<ResponseModel<OrganizationVM>>
    {
        public int OrgId { get; set; }
        [Required(ErrorMessage = "Organization Name is required")] 
        public string OrgName { get; set; }
        [Required(ErrorMessage = "Organization Code is required")] 
        public string OrgCode { get; set; }
        public string LandLineNo { get; set; }
        [Required(ErrorMessage = "Mobile No is required")]
        public string MobileNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PinCode { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "ULB Type is required")]
        public string ULBType { get; set; }
        public string GSTNo { get; set; }
        public int DistrictId { get; set; }
        public IFormFile OrgLogo { get; set; }
        [Required(ErrorMessage = "Short Name is required")]
        public string ShortName { get; set; }
        public bool IsHouseTax { get; set; }
        public bool IsWaterTax { get; set; }
        public bool IsSewerTax { get; set; }
        public int ARVFormulaId { get; set; }
    }
}
