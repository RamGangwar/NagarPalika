using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.AssetCategorys

{
    public class UpdateAssetCategoryCommand : IRequest<ResponseModel>
    {
        public int AssetCategoryId { get; set; }
        [Required(ErrorMessage = "AssetCategoryName is required")]
        public string AssetCategoryName { get; set; }
    }
}
