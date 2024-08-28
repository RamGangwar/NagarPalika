using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TradeRegistrations {
 public class DeleteTradeRegistrationCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "TradeRegistrationId is required")] public int TradeRegistrationId {get; set;}
}
}
