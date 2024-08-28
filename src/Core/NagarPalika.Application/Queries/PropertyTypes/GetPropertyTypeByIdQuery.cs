using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.PropertyTypes
{
    public class GetPropertyTypeByIdQuery : IRequest<ResponseModel<PropertyTypeVM>>
    {
        public int PropertyTypeId { get; set; }
    }
}
