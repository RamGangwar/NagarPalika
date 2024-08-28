using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.DisabilitySlabs {
 public class DeleteDisabilitySlabCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "DisabilitySlabId is required")] public int DisabilitySlabId {get; set;}
}
}
