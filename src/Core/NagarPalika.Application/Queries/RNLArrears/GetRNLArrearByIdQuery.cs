using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RNLArrears    
{        
public class GetRNLArrearByIdQuery : IRequest<ResponseModel<RNLArrearVM>>     
{public int RNLArrearId {get; set;}
}
}
