using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TariffPlans

{
    public class CreateTariffPlanCommand : IRequest<ResponseModel<TariffPlanVM>>
    {
        public int TariffPlanId { get; set; }
        //[Required(ErrorMessage = "PropertyType is required")]
        public string PropertyType { get; set; }
        //[Required(ErrorMessage = "ARV_NonAssessed is required")]
        public decimal ARV_NonAssessed { get; set; }
        //[Required(ErrorMessage = "ARV_Assessed is required")]
        public decimal ARV_Assessed { get; set; }
        //[Required(ErrorMessage = "HouseTax_LessThan is required")]
        public decimal HouseTax_LessThan { get; set; }
        //[Required(ErrorMessage = "HouseTax_MoreThan is required")]
        public decimal HouseTax_MoreThan { get; set; }
        //[Required(ErrorMessage = "HouseTax_LessThan_ForAssessed is required")]
        public decimal HouseTax_LessThan_ForNonAssessed { get; set; }
        //[Required(ErrorMessage = "HouseTax_MoreThan_ForNonAssessed is required")]
        public decimal HouseTax_MoreThan_ForNonAssessed { get; set; }
        //[Required(ErrorMessage = "WaterTax_LessThan is required")]
        public decimal WaterTax_LessThan { get; set; }
        //[Required(ErrorMessage = "WaterTax_MoreThan is required")]
        public decimal WaterTax_MoreThan { get; set; }
        //[Required(ErrorMessage = "WaterTax_LessThan_ForAssessed is required")]
        public decimal WaterTax_LessThan_ForNonAssessed { get; set; }
        //[Required(ErrorMessage = "WaterTax_MoreThan_ForNonAsssessed is required")]
        public decimal WaterTax_MoreThan_ForNonAssessed { get; set; }
        //[Required(ErrorMessage = "SewerTax_LessThan is required")]
        public decimal SewerTax_LessThan { get; set; }
        //[Required(ErrorMessage = "SewerTax_MoreThan is required")]
        public decimal SewerTax_MoreThan { get; set; }
        //[Required(ErrorMessage = "SewerTax_LessThan_ForAssessed is required")]
        public decimal SewerTax_LessThan_ForNonAssessed { get; set; }
        //[Required(ErrorMessage = "SewerTax_MoreThan_ForNonAsssessed is required")]
        public decimal SewerTax_MoreThan_ForNonAssessed { get; set; }
    }
}
