using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.PosessonModes    
{        
public class GetPosessonModeByIdQuery : IRequest<ResponseModel<PosessonModeVM>>     
{public int PosessonModeId {get; set;}
}
}
