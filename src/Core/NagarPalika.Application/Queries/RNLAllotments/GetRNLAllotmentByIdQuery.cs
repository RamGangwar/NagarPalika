using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RNLAllotments    
{        
public class GetRNLAllotmentByIdQuery : IRequest<ResponseModel<RNLAllotmentVM>>     
{public int RNLAllotmentId {get; set;}
}
}
