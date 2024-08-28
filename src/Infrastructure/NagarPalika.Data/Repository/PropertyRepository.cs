using Dapper;
using NagarPalika.Application.Queries.Propertys;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<PropertyVM>> GetByPaging(GetPropertyByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER() as TotalRecord, *from Property  ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY "); 
           DynamicParameters parameters = new DynamicParameters();
           parameters.Add("SkipRow", filterQuery.SkipRow);
           parameters.Add("PageSize", filterQuery.PageSize);
           return (await _DbConnection.QueryAsync<PropertyVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}

