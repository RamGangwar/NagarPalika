using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.ConstructionTypes

{
    public class CreateConstructionTypeCommand : IRequest<ResponseModel<ConstructionTypeVM>>
    {
        public int ConstructionTypeId { get; set; }
        [Required(ErrorMessage = "Construction Type Name is required")] 
        public string ConstructionTypeName { get; set; }
    }
}
