using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.Departments
{
    public class GetDepartmentByIdQuery : IRequest<ResponseModel<DepartmentVM>>
    {
        public int DepartmentId { get; set; }
    }
}
