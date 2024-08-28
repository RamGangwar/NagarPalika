using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RNLAllotments {
 public class CreateRNLAllotmentCommand : IRequest<ResponseModel<RNLAllotmentVM>>
{[Required(ErrorMessage = "RNLAllotmentId is required")] public int RNLAllotmentId {get; set;}
[Required(ErrorMessage = "AllottedTo is required")] public string AllottedTo {get; set;}
[Required(ErrorMessage = "FatherName is required")] public string FatherName {get; set;}
 public string ContactNo {get; set;}
 public string FullAddress {get; set;}
[Required(ErrorMessage = "Fees is required")] public decimal Fees {get; set;}
[Required(ErrorMessage = "FinancialYear is required")] public string FinancialYear {get; set;}
[Required(ErrorMessage = "AllotmentDate is required")] public DateTime AllotmentDate {get; set;}
 public DateTime? PossessionDate {get; set;}
 public string Attachment {get; set;}
[Required(ErrorMessage = "RNLPropertyId is required")] public int RNLPropertyId {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
}
}
