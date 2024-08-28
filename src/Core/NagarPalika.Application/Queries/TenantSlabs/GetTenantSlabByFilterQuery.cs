using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.TenantSlabs { public class GetTenantSlabByFilterQuery : PagingRquestModel, IRequest<PagingModel<TenantSlabVM>> {}
}
