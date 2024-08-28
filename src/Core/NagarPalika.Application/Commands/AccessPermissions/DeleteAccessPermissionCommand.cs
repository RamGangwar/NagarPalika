using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.AccessPermissions

{
    public class DeleteAccessPermissionCommand : IRequest<ResponseModel>
    {
        public int RoleId { get; set; }
    }
}
