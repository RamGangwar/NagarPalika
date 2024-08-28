using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.Districts {
 public class DeleteDistrictCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "DistrictId is required")] public int DistrictId {get; set;}
}
}
