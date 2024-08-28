using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TradeCategorys {
 public class UpdateTradeCategoryCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "TradeCategoryId is required")] public int TradeCategoryId {get; set;}
[Required(ErrorMessage = "TradeCategoryName is required")] public string TradeCategoryName {get; set;}
 public string TermAndCondition {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
[Required(ErrorMessage = "SessionMasterId is required")] public int SessionMasterId {get; set;}
}
}
