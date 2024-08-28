using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Http;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.PropertyTypes

{
    public class UpdatePropertyTypeCommand : IRequest<ResponseModel>
    {
        public int PropertyTypeId { get; set; }
        [Required(ErrorMessage = "Property Type is required")]
        public string PropertyTypeName { get; set; }
        [Required(ErrorMessage = "Grade is required")]
        public string Grade { get; set; }
        [Required(ErrorMessage = "Commercial Factor is required")]
        public int CommercialFactor { get; set; }
        public IFormFile? IconUrl { get; set; }
    }
}
