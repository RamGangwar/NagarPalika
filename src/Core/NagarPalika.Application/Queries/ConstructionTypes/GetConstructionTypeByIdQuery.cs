using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.ConstructionTypes    
{        
public class GetConstructionTypeByIdQuery : IRequest<ResponseModel<ConstructionTypeVM>>     
{public int ConstructionTypeId {get; set;}
}
}
