using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.Districts    
{        
public class GetDistrictByIdQuery : IRequest<ResponseModel<DistrictVM>>     
{public int DistrictId {get; set;}
}
}
