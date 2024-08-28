using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TradeCategorys

{
    public class CreateTradeCategoryCommand : IRequest<ResponseModel<TradeCategoryVM>>
    {
        public int TradeCategoryId { get; set; }
        [Required(ErrorMessage = "TradeCategoryName is required")]
        public string TradeCategoryName { get; set; }
        public string TermAndCondition { get; set; }
    }
}
