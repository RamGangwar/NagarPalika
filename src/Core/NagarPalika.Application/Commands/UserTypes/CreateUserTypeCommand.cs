using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.UserTypes {
 public class CreateUserTypeCommand : IRequest<ResponseModel<UserTypeVM>>
{[Required(ErrorMessage = "UserTypeId is required")] public int UserTypeId {get; set;}
[Required(ErrorMessage = "UserTypeName is required")] public string UserTypeName {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
}
}
