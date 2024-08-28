using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.AssetSubCategorys    
{        
public class GetAssetSubCategoryByIdQuery : IRequest<ResponseModel<AssetSubCategoryVM>>     
{public int AssetSubCategoryId {get; set;}
}
}
