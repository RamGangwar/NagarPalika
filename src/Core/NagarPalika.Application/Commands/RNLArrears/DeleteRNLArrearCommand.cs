using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RNLArrears {
 public class DeleteRNLArrearCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "RNLArrearId is required")] public int RNLArrearId {get; set;}
}
}
