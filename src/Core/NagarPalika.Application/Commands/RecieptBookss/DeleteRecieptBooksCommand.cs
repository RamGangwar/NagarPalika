using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Commands.RecieptBookss

{
    public class DeleteRecieptBooksCommand : IRequest<ResponseModel>
    {
        [Required(ErrorMessage = "RecieptBookId is required")] public int RecieptBookId { get; set; }
    }
}
