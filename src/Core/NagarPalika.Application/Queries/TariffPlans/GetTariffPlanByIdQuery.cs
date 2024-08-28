using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TariffPlans    
{        
public class GetTariffPlanByIdQuery : IRequest<ResponseModel<TariffPlanVM>>     
{public int TariffPlanId {get; set;}
}
}
