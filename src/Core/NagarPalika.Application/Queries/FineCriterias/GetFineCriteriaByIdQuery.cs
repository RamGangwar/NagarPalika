using MediatR;
using NagarPalika.Domain.Model; 
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.FineCriterias    
{        
public class GetFineCriteriaByIdQuery : IRequest<ResponseModel<FineCriteriaVM>>     
{public int FineCriteriaId {get; set;}
}
}
