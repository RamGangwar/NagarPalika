using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.MonthlyRentalRates

{
    public class CreateMonthlyRentalRateCommand : IRequest<ResponseModel<MonthlyRentalRateVM>>
    {
        public int MonthlyRentalRateId { get; set; }
        [Required(ErrorMessage = "Ward is required")]
        public int WardId { get; set; }
        [Required(ErrorMessage = "Locality is required")]
        public int LocalityId { get; set; }
        [Required(ErrorMessage = "Raod Width Type is required")]
        public int RaodWidthTypeId { get; set; }
        [Required(ErrorMessage = "Construction Type is required")]
        public int ConstructionTypeId { get; set; }
        [Required(ErrorMessage = "Constructed Area Rate is required")]
        public decimal ConstructedAreaRate { get; set; }
        [Required(ErrorMessage = "Empty Area Rate is required")]
        public decimal EmptyAreaRate { get; set; }
    }
}
