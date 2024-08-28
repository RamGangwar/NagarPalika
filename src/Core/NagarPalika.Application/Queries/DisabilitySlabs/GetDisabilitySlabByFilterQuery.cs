using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.DisabilitySlabs { public class GetDisabilitySlabByFilterQuery : PagingRquestModel, IRequest<PagingModel<DisabilitySlabVM>> {}
}
