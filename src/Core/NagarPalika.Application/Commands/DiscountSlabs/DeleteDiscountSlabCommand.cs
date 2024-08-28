using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.DiscountSlabs {
 public class DeleteDiscountSlabCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "DiscountSlabId is required")] public int DiscountSlabId {get; set;}
}
}
