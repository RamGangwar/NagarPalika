using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.AssetSubCategorys

{
    public class CreateAssetSubCategoryCommand : IRequest<ResponseModel<AssetSubCategoryVM>>
    {
        public int AssetSubCategoryId { get; set; }
        [Required(ErrorMessage = "AssetSubCategoryName is required")]
        public string AssetSubCategoryName { get; set; }
        [Required(ErrorMessage = "AssetCategoryId is required")]
        public int AssetCategoryId { get; set; }
    }
}
