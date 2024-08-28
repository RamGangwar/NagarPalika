using NagarPalika.Application.Queries.Modules;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IModuleRepository : IGenericRepository<Modules>
    {
        Task<List<ModulesVM>> GetByPaging(GetModulesByFilterQuery filterQuery);
        Task<List<ModulesVM>> GetListForAll();
        Task<bool> SaveEntityOrModel(int type);
        Task<string> SaveColumns(string entityname, int type=0);
    }
}
