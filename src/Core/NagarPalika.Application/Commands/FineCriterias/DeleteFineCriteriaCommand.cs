using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.FineCriterias {
 public class DeleteFineCriteriaCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "FineCriteriaId is required")] public int FineCriteriaId {get; set;}
}
}
