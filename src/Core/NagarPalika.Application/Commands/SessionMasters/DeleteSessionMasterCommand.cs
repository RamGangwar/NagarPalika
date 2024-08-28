using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.SessionMasters {
 public class DeleteSessionMasterCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "SessionMasterId is required")] public int SessionMasterId {get; set;}
}
}
