using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TradeDocuments {
 public class CreateTradeDocumentCommand : IRequest<ResponseModel<TradeDocumentVM>>
{[Required(ErrorMessage = "TradeDocumentId is required")] public int TradeDocumentId {get; set;}
[Required(ErrorMessage = "TradeDocumentName is required")] public string TradeDocumentName {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
[Required(ErrorMessage = "SessionMasterId is required")] public int SessionMasterId {get; set;}
}
}
