using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.AssetCategorys
{
    public class GetAssetCategoryByIdQuery : IRequest<ResponseModel<AssetCategoryVM>>
    {
        public int AssetCategoryId { get; set; }
    }
}
