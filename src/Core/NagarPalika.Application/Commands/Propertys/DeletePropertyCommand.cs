using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.Propertys {
 public class DeletePropertyCommand : IRequest<ResponseModel>
{[Required(ErrorMessage = "PropertyId is required")] public int PropertyId {get; set;}
}
}
