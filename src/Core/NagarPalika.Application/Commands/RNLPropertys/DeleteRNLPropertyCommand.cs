using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RNLPropertys {
 public class DeleteRNLPropertyCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "RNLPropertyId is required")] public int RNLPropertyId {get; set;}
}
}
