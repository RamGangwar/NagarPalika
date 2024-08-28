using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TradeSubCategorys {
 public class UpdateTradeSubCategoryCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "TradeSubCategoryId is required")] public int TradeSubCategoryId {get; set;}
[Required(ErrorMessage = "TradeSubCategoryName is required")] public string TradeSubCategoryName {get; set;}
[Required(ErrorMessage = "TradeCategoryId is required")] public int TradeCategoryId {get; set;}
[Required(ErrorMessage = "Fees is required")] public decimal Fees {get; set;}
 public string TermAndCondition {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
[Required(ErrorMessage = "SessionMasterId is required")] public int SessionMasterId {get; set;}
}
}
