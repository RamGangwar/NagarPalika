using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.MonthlyRentalRates {
 public class DeleteMonthlyRentalRateCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "MonthlyRentalRateId is required")] public int MonthlyRentalRateId {get; set;}
}
}
