using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RNLAllotments { public class GetRNLAllotmentByFilterQuery : PagingRquestModel, IRequest<PagingModel<RNLAllotmentVM>> {public int RNLAllotmentId {get; set;}
public string AllottedTo {get; set;}
public string FatherName {get; set;}
public string ContactNo {get; set;}
public string FullAddress {get; set;}
public decimal Fees {get; set;}
public string FinancialYear {get; set;}
public DateTime AllotmentDate {get; set;}
public DateTime? PossessionDate {get; set;}
public string Attachment {get; set;}
public int RNLPropertyId {get; set;}
}
}
