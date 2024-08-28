using NagarPalika.Application.Queries.TariffPlans;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface ITariffPlanRepository : IGenericRepository<TariffPlan>
    {
        Task<IEnumerable<TariffPlanVM>> GetByPaging(GetTariffPlanByFilterQuery filterQuery);
    }
}
