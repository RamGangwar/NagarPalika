using NagarPalika.Application.Queries.MonthlyRentalRates;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IMonthlyRentalRateRepository : IGenericRepository<MonthlyRentalRate>
    {
        Task<IEnumerable<MonthlyRentalRateVM>> GetByPaging(GetMonthlyRentalRateByFilterQuery filterQuery);
    }
}
