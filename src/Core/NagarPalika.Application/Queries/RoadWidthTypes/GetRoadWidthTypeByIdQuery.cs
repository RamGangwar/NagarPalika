using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.RoadWidthTypes    
{        
public class GetRoadWidthTypeByIdQuery : IRequest<ResponseModel<RoadWidthTypeVM>>     
{public int RoadWidthTypeId {get; set;}
}
}
