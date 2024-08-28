using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.Propertys    
{        
public class GetPropertyByIdQuery : IRequest<ResponseModel<PropertyVM>>     
{public int PropertyId {get; set;}
}
}
