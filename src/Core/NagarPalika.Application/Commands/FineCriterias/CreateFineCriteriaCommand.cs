using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.FineCriterias {
 public class CreateFineCriteriaCommand : IRequest<ResponseModel<FineCriteriaVM>>
{[Required(ErrorMessage = "FineCriteriaId is required")] public int FineCriteriaId {get; set;}
[Required(ErrorMessage = "PropertyType is required")] public string PropertyType {get; set;}
[Required(ErrorMessage = "ARVThreshold is required")] public decimal ARVThreshold {get; set;}
[Required(ErrorMessage = "HouseTax_LessThan is required")] public decimal HouseTax_LessThan {get; set;}
[Required(ErrorMessage = "HouseTax_MoreThan is required")] public decimal HouseTax_MoreThan {get; set;}
[Required(ErrorMessage = "WaterTax_LessThan is required")] public decimal WaterTax_LessThan {get; set;}
[Required(ErrorMessage = "WaterTax_MoreThan is required")] public decimal WaterTax_MoreThan {get; set;}
[Required(ErrorMessage = "SewerTax_LessThan is required")] public decimal SewerTax_LessThan {get; set;}
[Required(ErrorMessage = "SewerTax_MoreThan is required")] public decimal SewerTax_MoreThan {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
}
}
