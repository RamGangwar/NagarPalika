using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TradeRegistrations

{
    public class CreateTradeRegistrationCommand : IRequest<ResponseModel<TradeRegistrationVM>>
    {
        public int TradeRegistrationId { get; set; }
        [Required(ErrorMessage = "TradeCode is required")]
        public string TradeCode { get; set; }
        [Required(ErrorMessage = "ApplicationType is required")]
        public string ApplicationType { get; set; }
        [Required(ErrorMessage = "OwnerName is required")]
        public string OwnerName { get; set; }
        public string FatherName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Religion { get; set; }
        public string IdProofType { get; set; }
        public string IdProofNo { get; set; }
        public string Gender { get; set; }
        public string HouseNo { get; set; }
        [Required(ErrorMessage = "TradeName is required")]
        public string TradeName { get; set; }
        [Required(ErrorMessage = "TradeAddress is required")]
        public string TradeAddress { get; set; }
        [Required(ErrorMessage = "Zone is required")]
        public int ZoneId { get; set; }
        [Required(ErrorMessage = "Ward is required")]
        public int WardId { get; set; }
        [Required(ErrorMessage = "Locality is required")]
        public int LocalityId { get; set; }
        [Required(ErrorMessage = "TradeCategory is required")]
        public int TradeCategoryId { get; set; }
        [Required(ErrorMessage = "TradeSubCategory is required")]
        public int TradeSubCategoryId { get; set; }
        public DateTime? ARVEffectedDate { get; set; }
        public decimal Arrear { get; set; }
        public decimal ArrearFrom { get; set; }
        public decimal ArrearTill { get; set; }
    }
}
