using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TradeCategorys    
{        
public class GetTradeCategoryByIdQuery : IRequest<ResponseModel<TradeCategoryVM>>     
{public int TradeCategoryId {get; set;}
}
}
