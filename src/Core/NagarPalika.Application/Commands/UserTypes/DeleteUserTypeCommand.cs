using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.UserTypes {
 public class DeleteUserTypeCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "UserTypeId is required")] public int UserTypeId {get; set;}
}
}
