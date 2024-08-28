using Dapper;
 using NagarPalika.Application.Queries.RecieptBookss;
 using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class RecieptBooksRepository : GenericRepository<RecieptBooks>, IRecieptBooksRepository
    {
        public RecieptBooksRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<RecieptBooksVM>> GetByPaging(GetRecieptBooksByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER () as TotalRecord , RB.*, E.EmployeeName,AE.EmployeeName as AllowcatedEmployee  from RecieptBooks RB left join Employee E on RB.CreatedBy=E.EmployeeId  left join Employee AE on RB.AllowcatedTo=AE.EmployeeId where RB.BookType=@BookType ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("BookType", filterQuery.BookType);
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<RecieptBooksVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
