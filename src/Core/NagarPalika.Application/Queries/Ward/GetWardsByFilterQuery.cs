using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Ward
{
    public class GetWardsByFilterQuery : PagingRquestModel, IRequest<PagingModel<WardsVM>>
    {
    }
}
