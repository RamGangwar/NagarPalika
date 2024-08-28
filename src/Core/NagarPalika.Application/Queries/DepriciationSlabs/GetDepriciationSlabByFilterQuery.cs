using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.DepriciationSlabs { public class GetDepriciationSlabByFilterQuery : PagingRquestModel, IRequest<PagingModel<DepriciationSlabVM>> {}
}
