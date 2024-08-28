using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.DiscountSlabs    
{        
public class GetDiscountSlabByIdQuery : IRequest<ResponseModel<DiscountSlabVM>>     
{public int DiscountSlabId {get; set;}
}
}
