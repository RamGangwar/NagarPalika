using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TradeDocuments

{
    public class UpdateTradeDocumentCommand : IRequest<ResponseModel>
    {
        public int TradeDocumentId { get; set; }
        [Required(ErrorMessage = "TradeDocumentName is required")]
        public string TradeDocumentName { get; set; }
    }
}
