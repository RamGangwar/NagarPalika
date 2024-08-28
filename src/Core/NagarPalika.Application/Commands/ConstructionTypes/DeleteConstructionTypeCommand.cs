using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.ConstructionTypes {
 public class DeleteConstructionTypeCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "ConstructionTypeId is required")] public int ConstructionTypeId {get; set;}
}
}
