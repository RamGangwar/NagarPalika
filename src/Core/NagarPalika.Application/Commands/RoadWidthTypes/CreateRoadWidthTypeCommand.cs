using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RoadWidthTypes

{
    public class CreateRoadWidthTypeCommand : IRequest<ResponseModel<RoadWidthTypeVM>>
    {
        public int RoadWidthTypeId { get; set; }
        [Required(ErrorMessage = "Road Width Type required")]
        public string RoadWidthTypeName { get; set; }
    }
}
