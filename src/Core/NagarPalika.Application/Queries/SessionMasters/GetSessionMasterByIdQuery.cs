using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.SessionMasters    
{        
public class GetSessionMasterByIdQuery : IRequest<ResponseModel<SessionMasterVM>>     
{public int SessionMasterId {get; set;}
}
}
