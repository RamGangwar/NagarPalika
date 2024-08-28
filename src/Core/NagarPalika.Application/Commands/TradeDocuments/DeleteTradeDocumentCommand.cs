using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TradeDocuments {
 public class DeleteTradeDocumentCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "TradeDocumentId is required")] public int TradeDocumentId {get; set;}
}
}
