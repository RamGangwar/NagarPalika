using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.MonthlyRentalRates    
{        
public class GetMonthlyRentalRateByIdQuery : IRequest<ResponseModel<MonthlyRentalRateVM>>     
{public int MonthlyRentalRateId {get; set;}
}
}
