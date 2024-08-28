using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.MutationTypes

{
    public class CreateMutationTypeCommand : IRequest<ResponseModel<MutationTypeVM>>
    {
        public int MutationTypeId { get; set; }
        [Required(ErrorMessage = "MutationTypeName is required")] public string MutationTypeName { get; set; }
        [Required(ErrorMessage = "MutationFee is required")] public decimal MutationFee { get; set; }
    }
}
