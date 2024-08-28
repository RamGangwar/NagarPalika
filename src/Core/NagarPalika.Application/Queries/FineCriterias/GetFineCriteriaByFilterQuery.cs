using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.FineCriterias { public class GetFineCriteriaByFilterQuery : PagingRquestModel, IRequest<PagingModel<FineCriteriaVM>> {}
}
