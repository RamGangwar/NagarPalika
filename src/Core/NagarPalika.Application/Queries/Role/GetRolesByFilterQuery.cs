using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Role
{
    public class GetRolesByFilterQuery : PagingRquestModel, IRequest<PagingModel<RolesVM>>
    {
    }
}
