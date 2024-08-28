using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.DepriciationSlabs {
 public class DeleteDepriciationSlabCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "DepriciationSlabId is required")] public int DepriciationSlabId {get; set;}
}
}
