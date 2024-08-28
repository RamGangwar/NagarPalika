using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TariffPlans { public class GetTariffPlanByFilterQuery : PagingRquestModel, IRequest<PagingModel<TariffPlanVM>> {}
}
