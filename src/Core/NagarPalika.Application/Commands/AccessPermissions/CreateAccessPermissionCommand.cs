using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.AccessPermissions

{
    public class CreateAccessPermissionCommand : IRequest<ResponseModel<AccessPermissionVM>>
    {
        [Required(ErrorMessage = "Role is required")]
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public int SessionMasterId { get; set; }
        public List<AccessPermissionData> PermissionDatas { get; set; }
    }
    public class AccessPermissionData
    {
        public int ModuleId { get; set; }
        public int ParentId { get; set; }
        public string ModuleName { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanView { get; set; }
    }
}
