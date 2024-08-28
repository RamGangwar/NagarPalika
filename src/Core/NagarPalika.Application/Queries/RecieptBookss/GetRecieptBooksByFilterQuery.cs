using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RecieptBookss
{
    public class GetRecieptBooksByFilterQuery : PagingRquestModel, IRequest<PagingModel<RecieptBooksVM>>
    {
        public string BookType { get; set; }
    }
}
