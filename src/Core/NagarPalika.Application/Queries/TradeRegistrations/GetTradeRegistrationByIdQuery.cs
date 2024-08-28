using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TradeRegistrations    
{        
public class GetTradeRegistrationByIdQuery : IRequest<ResponseModel<TradeRegistrationVM>>     
{public int TradeRegistrationId {get; set;}
}
}
