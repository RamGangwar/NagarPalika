using NagarPalika.Application.Queries.TradeDocuments;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface ITradeDocumentRepository : IGenericRepository<TradeDocument>
    {
        Task<IEnumerable<TradeDocumentVM>> GetByPaging(GetTradeDocumentByFilterQuery filterQuery);
    }
}

