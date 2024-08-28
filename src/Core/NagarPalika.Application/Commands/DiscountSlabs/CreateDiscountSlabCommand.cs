using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.DiscountSlabs

{
    public class CreateDiscountSlabCommand : IRequest<ResponseModel<DiscountSlabVM>>
    {
        public int DiscountSlabId { get; set; }
        [Required(ErrorMessage = "PropertyType is required")] 
        public string PropertyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Value is required")] 
        public decimal Value { get; set; }
        public bool SkipCondition { get; set; }
    }
}
