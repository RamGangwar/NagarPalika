using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TariffPlans {
 public class DeleteTariffPlanCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "TariffPlanId is required")] public int TariffPlanId {get; set;}
}
}
