using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.DiscountSlabs {
 public class UpdateDiscountSlabCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "DiscountSlabId is required")] public int DiscountSlabId {get; set;}
[Required(ErrorMessage = "PropertyType is required")] public string PropertyType {get; set;}
[Required(ErrorMessage = "StartDate is required")] public DateTime StartDate {get; set;}
[Required(ErrorMessage = "EndDate is required")] public DateTime EndDate {get; set;}
[Required(ErrorMessage = "Value is required")] public decimal Value {get; set;}
[Required(ErrorMessage = "SkipCondition is required")] public bool SkipCondition {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
}
}
