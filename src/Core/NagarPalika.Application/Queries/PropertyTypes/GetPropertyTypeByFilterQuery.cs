using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.PropertyTypes
{
    public class GetPropertyTypeByFilterQuery : PagingRquestModel, IRequest<PagingModel<PropertyTypeVM>>
    { }
}
