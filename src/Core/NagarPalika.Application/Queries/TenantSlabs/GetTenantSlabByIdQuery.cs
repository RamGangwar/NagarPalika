using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TenantSlabs    
{        
public class GetTenantSlabByIdQuery : IRequest<ResponseModel<TenantSlabVM>>     
{public int TenantSlabId {get; set;}
}
}
