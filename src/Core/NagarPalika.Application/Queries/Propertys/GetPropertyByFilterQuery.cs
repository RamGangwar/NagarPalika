using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.Propertys { public class GetPropertyByFilterQuery : PagingRquestModel, IRequest<PagingModel<PropertyVM>> {public int PropertyId {get; set;}
public int ZoneId {get; set;}
public int WardId {get; set;}
public int LocalityId {get; set;}
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
public bool IsDepriciation {get; set;}
public bool IsDisabled {get; set;}
public bool IsRented {get; set;}
public decimal FinalARV {get; set;}
public DateTime? ARVEffectedFrom {get; set;}
public bool IsHouseTax {get; set;}
public bool IsWaterTax {get; set;}
public bool IsSewerTax {get; set;}
public string Attachment {get; set;}
public bool IsDeActivatedOldProperty {get; set;}
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
public int SessionMasterId {get; set;}
}
}
