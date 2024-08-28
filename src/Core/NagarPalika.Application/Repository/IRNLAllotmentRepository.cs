using NagarPalika.Application.Queries.RNLAllotments;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IRNLAllotmentRepository : IGenericRepository<RNLAllotment>
    {
        Task<IEnumerable<RNLAllotmentVM>> GetByPaging(GetRNLAllotmentByFilterQuery filterQuery);
    }
}

