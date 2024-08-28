using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.UserTypes    
{        
public class GetUserTypeByIdQuery : IRequest<ResponseModel<UserTypeVM>>     
{public int UserTypeId {get; set;}
}
}
