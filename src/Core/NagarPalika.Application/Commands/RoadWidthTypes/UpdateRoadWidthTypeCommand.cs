using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RoadWidthTypes {
 public class UpdateRoadWidthTypeCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "RoadWidthTypeId is required")] public int RoadWidthTypeId {get; set;}
[Required(ErrorMessage = "RoadWidthTypeName is required")] public string RoadWidthTypeName {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
}
}
