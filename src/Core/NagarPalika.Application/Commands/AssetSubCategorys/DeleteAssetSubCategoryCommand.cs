using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.AssetSubCategorys {
 public class DeleteAssetSubCategoryCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "AssetSubCategoryId is required")] public int AssetSubCategoryId {get; set;}
}
}
