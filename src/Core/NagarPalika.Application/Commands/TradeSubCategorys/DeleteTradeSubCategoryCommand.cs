using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TradeSubCategorys {
 public class DeleteTradeSubCategoryCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "TradeSubCategoryId is required")] public int TradeSubCategoryId {get; set;}
}
}
