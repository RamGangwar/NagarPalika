using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Role
{
    public class GetRolesByIdQuery : IRequest<ResponseModel<RolesVM>>
    {
        public int RoleId { get; set; }
    }
}
