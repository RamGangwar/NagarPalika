using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RNLPropertys {
 public class UpdateRNLPropertyCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "RNLPropertyId is required")] public int RNLPropertyId {get; set;}
[Required(ErrorMessage = "RNLPropertyName is required")] public string RNLPropertyName {get; set;}
 public string RNLPropertyNo {get; set;}
[Required(ErrorMessage = "Fees is required")] public decimal Fees {get; set;}
[Required(ErrorMessage = "PaymentType is required")] public string PaymentType {get; set;}
[Required(ErrorMessage = "CoveredArea is required")] public decimal CoveredArea {get; set;}
[Required(ErrorMessage = "EmptyArea is required")] public decimal EmptyArea {get; set;}
[Required(ErrorMessage = "TotalArea is required")] public decimal TotalArea {get; set;}
 public DateTime? EstablishedDate {get; set;}
 public string Remarks {get; set;}
[Required(ErrorMessage = "ZoneId is required")] public int ZoneId {get; set;}
[Required(ErrorMessage = "WardId is required")] public int WardId {get; set;}
[Required(ErrorMessage = "LocalityId is required")] public int LocalityId {get; set;}
 public string PTINCode {get; set;}
[Required(ErrorMessage = "AssetCategoryId is required")] public int AssetCategoryId {get; set;}
[Required(ErrorMessage = "AssetSubCategoryId is required")] public int AssetSubCategoryId {get; set;}
 public string Floor {get; set;}
[Required(ErrorMessage = "PosessonModeId is required")] public int PosessonModeId {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
}
}
