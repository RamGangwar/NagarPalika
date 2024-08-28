using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.AssetCategorys {
 public class DeleteAssetCategoryCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "AssetCategoryId is required")] public int AssetCategoryId {get; set;}
}
}
