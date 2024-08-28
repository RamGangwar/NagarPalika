using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.DisabilitySlabs    
{        
public class GetDisabilitySlabByIdQuery : IRequest<ResponseModel<DisabilitySlabVM>>     
{public int DisabilitySlabId {get; set;}
}
}
