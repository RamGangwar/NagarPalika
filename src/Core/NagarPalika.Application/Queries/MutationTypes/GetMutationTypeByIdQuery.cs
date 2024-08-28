using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.MutationTypes    
{        
public class GetMutationTypeByIdQuery : IRequest<ResponseModel<MutationTypeVM>>     
{public int MutationTypeId {get; set;}
}
}
