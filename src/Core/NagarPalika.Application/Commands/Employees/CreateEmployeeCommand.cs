using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.User
{
    public class CreateEmployeeCommand : IRequest<ResponseModel<EmployeeVM>>
    {

        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Employee Full Name is required")] 
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Father Name is required")] 
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Mobile No is required")] 
        public string MobileNo { get; set; }
        public string? AlternateMobileNo { get; set; }

        [EmailAddress]
        public string? EmailId { get; set; }

        [Required(ErrorMessage = "Full Address is required")] 
        public string FullAddress { get; set; }
        [Required(ErrorMessage = "Organization is required")]
        public int OrganizationId { get; set; }
        [Required(ErrorMessage = "Department is required")] 
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Designation is required")] 
        public int DesignationId { get; set; }
        public string Level { get; set; }
        public int? ReportingEmployeeId { get; set; }
        [Required(ErrorMessage = "RoleId is required")] 
        public int RoleId { get; set; }
        [Required(ErrorMessage = "UserType is required")] 
        public int UserTypeId { get; set; }
        public IFormFile ProfilePic { get; set; }
        
    }
}
