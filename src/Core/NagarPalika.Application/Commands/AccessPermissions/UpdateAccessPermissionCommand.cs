using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.AccessPermissions {
 public class UpdateAccessPermissionCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "PermissionId is required")] public int PermissionId {get; set;}
[Required(ErrorMessage = "RoleId is required")] public int RoleId {get; set;}
[Required(ErrorMessage = "ModuleId is required")] public int ModuleId {get; set;}
[Required(ErrorMessage = "CanAdd is required")] public bool CanAdd {get; set;}
[Required(ErrorMessage = "CanEdit is required")] public bool CanEdit {get; set;}
[Required(ErrorMessage = "CanDelete is required")] public bool CanDelete {get; set;}
[Required(ErrorMessage = "CanView is required")] public bool CanView {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
[Required(ErrorMessage = "SessionMasterId is required")] public int SessionMasterId {get; set;}
}
}
