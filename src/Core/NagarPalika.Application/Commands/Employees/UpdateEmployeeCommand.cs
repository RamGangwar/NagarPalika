using MediatR;
using Microsoft.AspNetCore.Http;
using NagarPalika.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace NagarPalika.Application.Commands.Employees
{
    public class UpdateEmployeeCommand : IRequest<ResponseModel>
    {
        public int EmployeeId { get; set; }
        
        [Required(ErrorMessage = "Employee Full Name is required")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Father Name is required")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Mobile No is required")]
        public string MobileNo { get; set; }
        public string AlternateMobileNo { get; set; }

        [EmailAddress]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Full Address is required")]
        public string FullAddress { get; set; }
        [Required(ErrorMessage = "Organization is required")]
        public int OrganizationId { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        public int DesignationId { get; set; }
        public string Level { get; set; }
        [Required(ErrorMessage = "Reporting Manager is required")]
        public int ReportingEmployeeId { get; set; }
        [Required(ErrorMessage = "RoleId is required")]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "UserType is required")]
        public int UserTypeId { get; set; }
        public IFormFile ProfilePicURL { get; set; }

    }
}
