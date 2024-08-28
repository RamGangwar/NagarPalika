using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Zone
{
    public class GetZonesByFilterQuery : PagingRquestModel, IRequest<PagingModel<ZonesVM>>
    {
    }
}
