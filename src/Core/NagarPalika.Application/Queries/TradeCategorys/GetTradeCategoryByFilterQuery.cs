using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TradeCategorys { public class GetTradeCategoryByFilterQuery : PagingRquestModel, IRequest<PagingModel<TradeCategoryVM>> {public int TradeCategoryId {get; set;}
public string TradeCategoryName {get; set;}
public string TermAndCondition {get; set;}
public int SessionMasterId {get; set;}
}
}
