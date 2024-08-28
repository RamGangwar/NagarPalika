using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RoadWidthTypes
{
    public class GetRoadWidthTypeByFilterQuery : PagingRquestModel, IRequest<PagingModel<RoadWidthTypeVM>> { }
}
