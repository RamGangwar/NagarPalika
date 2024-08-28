using NagarPalika.Application.Queries.TradeRegistrations;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface ITradeRegistrationRepository : IGenericRepository<TradeRegistration>
    {
        Task<IEnumerable<TradeRegistrationVM>> GetByPaging(GetTradeRegistrationByFilterQuery filterQuery);
    }
}

