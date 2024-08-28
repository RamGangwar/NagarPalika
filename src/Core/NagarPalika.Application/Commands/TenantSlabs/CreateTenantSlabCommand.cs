using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TenantSlabs

{
    public class CreateTenantSlabCommand : IRequest<ResponseModel<TenantSlabVM>>
    {
        public int TenantSlabId { get; set; }
        [Required(ErrorMessage = "PropertyType is required")] public string PropertyType { get; set; }
        [Required(ErrorMessage = "SlabStartValue is required")] public decimal SlabStartValue { get; set; }
        [Required(ErrorMessage = "SlabEndValue is required")] public decimal SlabEndValue { get; set; }
        [Required(ErrorMessage = "Value is required")] public decimal Value { get; set; }
    }
}
