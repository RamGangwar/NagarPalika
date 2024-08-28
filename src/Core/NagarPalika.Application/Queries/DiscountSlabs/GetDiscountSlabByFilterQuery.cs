using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.DiscountSlabs { public class GetDiscountSlabByFilterQuery : PagingRquestModel, IRequest<PagingModel<DiscountSlabVM>> {}
}
