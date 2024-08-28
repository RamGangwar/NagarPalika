using MediatR;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.Departments
{
    public class DeleteDepartmentCommand:IRequest<ResponseModel>
    {
        public int DepartmentId { get; set; }
    }
}
