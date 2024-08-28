using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TradeDocuments    
{        
public class GetTradeDocumentByIdQuery : IRequest<ResponseModel<TradeDocumentVM>>     
{public int TradeDocumentId {get; set;}
}
}
