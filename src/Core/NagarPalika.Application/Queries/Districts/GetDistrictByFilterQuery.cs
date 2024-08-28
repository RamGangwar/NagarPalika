using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.Districts { public class GetDistrictByFilterQuery : PagingRquestModel, IRequest<PagingModel<DistrictVM>> {public int DistrictId {get; set;}
public string DistrictName {get; set;}
public string DistrictCode {get; set;}
public int StateId {get; set;}
}
}
