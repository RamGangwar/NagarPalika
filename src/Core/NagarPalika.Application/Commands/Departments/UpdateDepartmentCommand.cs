using MediatR;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Departments
{
    public class UpdateDepartmentCommand : IRequest<ResponseModel>
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }
    }
}
