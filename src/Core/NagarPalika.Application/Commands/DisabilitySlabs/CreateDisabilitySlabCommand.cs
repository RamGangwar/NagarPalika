using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.DisabilitySlabs

{
    public class CreateDisabilitySlabCommand : IRequest<ResponseModel<DisabilitySlabVM>>
    {
        public int DisabilitySlabId { get; set; }
        [Required(ErrorMessage = "Property Type is required")] public string PropertyType { get; set; }
        [Required(ErrorMessage = "Start Value is required")] public decimal StartValue { get; set; }
        [Required(ErrorMessage = "End Value is required")] public decimal EndValue { get; set; }
        [Required(ErrorMessage = "Value is required")] public decimal Value { get; set; }
    }
}
