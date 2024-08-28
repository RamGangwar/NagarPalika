using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Departments
{
    public class GetDepartmentByFilterQuery : PagingRquestModel, IRequest<PagingModel<DepartmentVM>>
    {
    }
}
