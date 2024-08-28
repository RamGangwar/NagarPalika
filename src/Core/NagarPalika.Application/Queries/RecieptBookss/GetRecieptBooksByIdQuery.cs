using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RecieptBookss    
{        
public class GetRecieptBooksByIdQuery : IRequest<ResponseModel<RecieptBooksVM>>     
{public int RecieptBookId {get; set;}
}
}
