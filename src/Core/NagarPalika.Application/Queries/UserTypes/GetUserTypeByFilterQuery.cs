using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.UserTypes { public class GetUserTypeByFilterQuery : PagingRquestModel, IRequest<PagingModel<UserTypeVM>> {public int UserTypeId {get; set;}
public string UserTypeName {get; set;}
}
}
