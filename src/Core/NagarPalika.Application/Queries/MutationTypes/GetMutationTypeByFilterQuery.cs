using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.MutationTypes { public class GetMutationTypeByFilterQuery : PagingRquestModel, IRequest<PagingModel<MutationTypeVM>> {}
}
