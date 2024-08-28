using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.AccessPermissions    
{        
public class GetAccessPermissionByIdQuery : IRequest<ResponseModel<AccessPermissionVM>>     
{public int PermissionId {get; set;}
}
}
