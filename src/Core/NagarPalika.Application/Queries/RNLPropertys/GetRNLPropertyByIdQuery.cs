using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RNLPropertys
{
    public class GetRNLPropertyByIdQuery : IRequest<ResponseModel<RNLPropertyVM>>
    {
        public int RNLPropertyId { get; set; }
    }
}
