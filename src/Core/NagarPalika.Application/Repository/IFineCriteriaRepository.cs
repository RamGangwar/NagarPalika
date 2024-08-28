using NagarPalika.Application.Queries.FineCriterias;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IFineCriteriaRepository : IGenericRepository<FineCriteria>
    {
        Task<IEnumerable<FineCriteriaVM>> GetByPaging(GetFineCriteriaByFilterQuery filterQuery);
    }
}
