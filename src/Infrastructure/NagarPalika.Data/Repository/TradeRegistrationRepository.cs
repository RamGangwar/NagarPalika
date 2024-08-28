using Dapper;
using NagarPalika.Application.Queries.TradeRegistrations;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class TradeRegistrationRepository : GenericRepository<TradeRegistration>, ITradeRegistrationRepository
    {
        public TradeRegistrationRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<TradeRegistrationVM>> GetByPaging(GetTradeRegistrationByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select COUNT(1) OVER() as TotalRecord, TR.*,Z.ZoneName,W.WardName,L.LocalityName,TC.TradeCategoryName,TS.TradeSubCategoryName,E.EmployeeName from TradeRegistration TR  left join Zones Z on TR.ZoneId=Z.ZoneId left join Wards W on TR.WardId=W.WardId left join Locality L on TR.LocalityId=L.LocalityId left join TradeCategory TC on TR.TradeCategoryId=TC.TradeCategoryId left join TradeSubCategory TS on TR.TradeSubCategoryId=TS.TradeSubCategoryId left join Employee E on TR.CreatedBy = E.EmployeeId ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<TradeRegistrationVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}

