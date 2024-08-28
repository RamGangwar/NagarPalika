using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Zone
{
    public class GetZonesByIdQuery : IRequest<ResponseModel<ZonesVM>>
    {
        public int ZoneId { get; set; }
    }
}
