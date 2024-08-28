using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.MonthlyRentalRates { public class GetMonthlyRentalRateByFilterQuery : PagingRquestModel, IRequest<PagingModel<MonthlyRentalRateVM>> {}
}
