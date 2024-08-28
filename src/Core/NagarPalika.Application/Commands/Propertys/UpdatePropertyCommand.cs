using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.Propertys {
 public class UpdatePropertyCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "PropertyId is required")] public int PropertyId {get; set;}
[Required(ErrorMessage = "ZoneId is required")] public int ZoneId {get; set;}
[Required(ErrorMessage = "WardId is required")] public int WardId {get; set;}
[Required(ErrorMessage = "LocalityId is required")] public int LocalityId {get; set;}
 public string PropertyOwnerShipType {get; set;}
 public string OwnerName {get; set;}
 public string FatherName {get; set;}
 public string MobileNo {get; set;}
 public string Gender {get; set;}
 public string HouseNo {get; set;}
 public string OldHouseNo {get; set;}
 public string Address {get; set;}
 public int PropertyTypeId {get; set;}
 public int RoadWidthTypeId {get; set;}
 public int ConstructionTypeId {get; set;}
 public int ConstructionYear {get; set;}
 public decimal DepriciationPercent {get; set;}
[Required(ErrorMessage = "IsDepriciation is required")] public bool IsDepriciation {get; set;}
[Required(ErrorMessage = "IsDisabled is required")] public bool IsDisabled {get; set;}
[Required(ErrorMessage = "IsRented is required")] public bool IsRented {get; set;}
 public decimal FinalARV {get; set;}
 public DateTime? ARVEffectedFrom {get; set;}
[Required(ErrorMessage = "IsHouseTax is required")] public bool IsHouseTax {get; set;}
[Required(ErrorMessage = "IsWaterTax is required")] public bool IsWaterTax {get; set;}
[Required(ErrorMessage = "IsSewerTax is required")] public bool IsSewerTax {get; set;}
 public string Attachment {get; set;}
[Required(ErrorMessage = "IsDeActivatedOldProperty is required")] public bool IsDeActivatedOldProperty {get; set;}
 public int RoadWidthTypeIdPrev {get; set;}
 public int ConstructionTypeIdPrev {get; set;}
 public decimal ARVPrevResidencial {get; set;}
 public decimal ARVPrevCommercial {get; set;}
 public decimal ArrearHouseTax {get; set;}
 public decimal ArrearWaterTax {get; set;}
 public decimal ArrearSewerTax {get; set;}
 public decimal ProposedARV {get; set;}
 public decimal SurchargeHouseTax {get; set;}
 public decimal SurchargeWaterTax {get; set;}
 public decimal SurchargeSewerTax {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
[Required(ErrorMessage = "SessionMasterId is required")] public int SessionMasterId {get; set;}
}
}
