using NagarPalika.Application.Queries.RecieptBookss;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Repository
{
    public interface IRecieptBooksRepository : IGenericRepository<RecieptBooks>
    {
        Task<IEnumerable<RecieptBooksVM>> GetByPaging(GetRecieptBooksByFilterQuery filterQuery);
    }
}
