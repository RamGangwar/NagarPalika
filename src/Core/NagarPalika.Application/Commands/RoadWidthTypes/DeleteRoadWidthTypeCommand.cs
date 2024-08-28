using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RoadWidthTypes {
 public class DeleteRoadWidthTypeCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "RoadWidthTypeId is required")] public int RoadWidthTypeId {get; set;}
}
}
