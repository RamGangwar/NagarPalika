using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TradeDocuments
{
    public class GetTradeDocumentByFilterQuery : PagingRquestModel, IRequest<PagingModel<TradeDocumentVM>>
    {
        public int TradeDocumentId { get; set; }
        public string TradeDocumentName { get; set; }
    }
}
