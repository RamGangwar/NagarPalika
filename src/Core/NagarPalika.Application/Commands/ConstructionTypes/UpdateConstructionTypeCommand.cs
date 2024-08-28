using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.ConstructionTypes {
 public class UpdateConstructionTypeCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "ConstructionTypeId is required")] public int ConstructionTypeId {get; set;}
[Required(ErrorMessage = "ConstructionTypeName is required")] public string ConstructionTypeName {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
}
}
