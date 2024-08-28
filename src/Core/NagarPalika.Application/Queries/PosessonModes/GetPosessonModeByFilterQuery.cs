using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.PosessonModes { public class GetPosessonModeByFilterQuery : PagingRquestModel, IRequest<PagingModel<PosessonModeVM>> {public int PosessonModeId {get; set;}
public string PosessonModeName {get; set;}
}
}
