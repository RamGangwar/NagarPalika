using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.Districts {
 public class UpdateDistrictCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "DistrictId is required")] public int DistrictId {get; set;}
[Required(ErrorMessage = "DistrictName is required")] public string DistrictName {get; set;}
[Required(ErrorMessage = "DistrictCode is required")] public string DistrictCode {get; set;}
 public int StateId {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
}
}
