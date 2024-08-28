using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace NagarPalika.Application.Commands.Departments
{
    public class CreateDepartmentCommand : IRequest<ResponseModel<DepartmentVM>>
    {
        [Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }

    }
}
