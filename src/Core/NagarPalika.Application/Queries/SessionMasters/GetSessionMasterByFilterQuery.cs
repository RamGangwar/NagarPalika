using System.ComponentModel.DataAnnotations;
using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
namespace NagarPalika.Application.Queries.SessionMasters
{
    public class GetSessionMasterByFilterQuery : PagingRquestModel, IRequest<PagingModel<SessionMasterVM>>
    {
        public int SessionMasterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SessionName { get; set; }
    }
}
