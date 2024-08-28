using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.DepriciationSlabs

{
    public class CreateDepriciationSlabCommand : IRequest<ResponseModel<DepriciationSlabVM>>
    {
        public int DepriciationSlabId { get; set; }
        [Required(ErrorMessage = "Property Type is required")]
        public string PropertyType { get; set; }
        [Required(ErrorMessage = "Start Value is required")]
        public decimal StartValue { get; set; }
        [Required(ErrorMessage = "EndV alue is required")]
        public decimal EndValue { get; set; }
        [Required(ErrorMessage = "Value is required")]
        public decimal Value { get; set; }
    }
}
