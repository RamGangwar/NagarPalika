using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Ward
{
    public class GetWardsByIdQuery : IRequest<ResponseModel<WardsVM>>
    {
        public int WardId { get; set; }
    }
}
