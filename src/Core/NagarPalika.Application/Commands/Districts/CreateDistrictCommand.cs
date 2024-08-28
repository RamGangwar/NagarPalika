using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.Districts

{
    public class CreateDistrictCommand : IRequest<ResponseModel<DistrictVM>>
    {
        public int DistrictId { get; set; }
        [Required(ErrorMessage = "District Name is required")] 
        public string DistrictName { get; set; }
        [Required(ErrorMessage = "District Code is required")] 
        public string DistrictCode { get; set; }
       
    }
}
