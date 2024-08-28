using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.TenantSlabs {
 public class DeleteTenantSlabCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "TenantSlabId is required")] public int TenantSlabId {get; set;}
}
}
