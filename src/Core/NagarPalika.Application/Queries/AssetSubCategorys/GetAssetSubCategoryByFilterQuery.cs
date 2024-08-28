using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.AssetSubCategorys { public class GetAssetSubCategoryByFilterQuery : PagingRquestModel, IRequest<PagingModel<AssetSubCategoryVM>> {public int AssetSubCategoryId {get; set;}
public string AssetSubCategoryName {get; set;}
public int AssetCategoryId {get; set;}
}
}
