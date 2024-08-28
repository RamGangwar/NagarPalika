using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.MonthlyRentalRates

{
    public class UpdateMonthlyRentalRateCommand : IRequest<ResponseModel>
    {
         public int MonthlyRentalRateId { get; set; }
        [Required(ErrorMessage = "WardId is required")] 
        public int WardId { get; set; }
        [Required(ErrorMessage = "LocalityId is required")] 
        public int LocalityId { get; set; }
        [Required(ErrorMessage = "RaodWidthTypeId is required")] 
        public int RaodWidthTypeId { get; set; }
        [Required(ErrorMessage = "ConstructionTypeId is required")] 
        public int ConstructionTypeId { get; set; }
        [Required(ErrorMessage = "ConstructedAreaRate is required")] 
        public decimal ConstructedAreaRate { get; set; }
        [Required(ErrorMessage = "EmptyAreaRate is required")] 
        public decimal EmptyAreaRate { get; set; }
    }
}
