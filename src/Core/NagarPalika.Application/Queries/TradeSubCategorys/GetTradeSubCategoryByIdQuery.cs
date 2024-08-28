using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TradeSubCategorys    
{        
public class GetTradeSubCategoryByIdQuery : IRequest<ResponseModel<TradeSubCategoryVM>>     
{public int TradeSubCategoryId {get; set;}
}
}
