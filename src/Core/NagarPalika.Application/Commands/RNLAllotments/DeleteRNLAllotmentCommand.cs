using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RNLAllotments {
 public class DeleteRNLAllotmentCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "RNLAllotmentId is required")] public int RNLAllotmentId {get; set;}
}
}
