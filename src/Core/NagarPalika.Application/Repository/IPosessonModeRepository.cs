using NagarPalika.Application.Queries.PosessonModes;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IPosessonModeRepository : IGenericRepository<PosessonMode>
    {
        Task<IEnumerable<PosessonModeVM>> GetByPaging(GetPosessonModeByFilterQuery filterQuery);
    }
}

