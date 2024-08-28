using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RNLArrears {
 public class UpdateRNLArrearCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "RNLArrearId is required")] public int RNLArrearId {get; set;}
[Required(ErrorMessage = "AllottedTo is required")] public string AllottedTo {get; set;}
[Required(ErrorMessage = "ArrearAmount is required")] public decimal ArrearAmount {get; set;}
 public string Remark {get; set;}
[Required(ErrorMessage = "RNLAllotmentId is required")] public int RNLAllotmentId {get; set;}
[Required(ErrorMessage = "IsActive is required")] public bool IsActive {get; set;}
}
}
