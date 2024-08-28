using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.MutationTypes {
 public class DeleteMutationTypeCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "MutationTypeId is required")] public int MutationTypeId {get; set;}
}
}
