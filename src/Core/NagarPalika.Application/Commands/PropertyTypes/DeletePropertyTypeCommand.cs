using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.PropertyTypes {
 public class DeletePropertyTypeCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "PropertyTypeId is required")] public int PropertyTypeId {get; set;}
}
}
