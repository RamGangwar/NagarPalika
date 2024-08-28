using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.DepriciationSlabs    
{        
public class GetDepriciationSlabByIdQuery : IRequest<ResponseModel<DepriciationSlabVM>>     
{public int DepriciationSlabId {get; set;}
}
}
