using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.AccessPermissions
{
    public class GetAccessPermissionByFilterQuery : PagingRquestModel, IRequest<List<AccessPermissionVM>>
    {
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
    }
}
