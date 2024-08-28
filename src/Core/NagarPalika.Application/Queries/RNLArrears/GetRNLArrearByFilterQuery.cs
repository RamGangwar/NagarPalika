using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RNLArrears { public class GetRNLArrearByFilterQuery : PagingRquestModel, IRequest<PagingModel<RNLArrearVM>> {public int RNLArrearId {get; set;}
public string AllottedTo {get; set;}
public decimal ArrearAmount {get; set;}
public string Remark {get; set;}
public int RNLAllotmentId {get; set;}
}
}
