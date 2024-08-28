using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TradeSubCategorys { public class GetTradeSubCategoryByFilterQuery : PagingRquestModel, IRequest<PagingModel<TradeSubCategoryVM>> {public int TradeSubCategoryId {get; set;}
public string TradeSubCategoryName {get; set;}
public int TradeCategoryId {get; set;}
public decimal Fees {get; set;}
public string TermAndCondition {get; set;}
public int SessionMasterId {get; set;}
}
}
