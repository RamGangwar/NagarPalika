using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.AssetCategorys { public class GetAssetCategoryByFilterQuery : PagingRquestModel, IRequest<PagingModel<AssetCategoryVM>> {public int AssetCategoryId {get; set;}
public string AssetCategoryName {get; set;}
}
}
