using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TradeCategorys {
 public class DeleteTradeCategoryCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "TradeCategoryId is required")] public int TradeCategoryId {get; set;}
}
}
