using Dapper;
 using NagarPalika.Application.Queries.MonthlyRentalRates;
 using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class MonthlyRentalRateRepository : GenericRepository<MonthlyRentalRate>, IMonthlyRentalRateRepository
    {
        public MonthlyRentalRateRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IEnumerable<MonthlyRentalRateVM>> GetByPaging(GetMonthlyRentalRateByFilterQuery filterQuery)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"Select COUNT(1) OVER () as TotalRecord , MR.*,W.WardName,L.LocalityName,RW.RoadWidthTypeName,CT.ConstructionTypeName,E.EmployeeName from MonthlyRentalRate  MR left join Wards W on MR.WardId=W.WardId Left join Locality L on MR.LocalityId =L.LocalityId left join RoadWidthType RW on MR.RaodWidthTypeId=RW.RoadWidthTypeId left join ConstructionType CT on MR.ConstructionTypeId=CT.ConstructionTypeId left join Employee E on MR.CreatedBy=E.EmployeeId ORDER BY " + filterQuery.SortBy + " " + filterQuery.SortOrder + " OFFSET @SkipRow ROWS FETCH NEXT @PageSize ROWS ONLY ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("SkipRow", filterQuery.SkipRow);
            parameters.Add("PageSize", filterQuery.PageSize);
            return (await _DbConnection.QueryAsync<MonthlyRentalRateVM>(sb.ToString(), parameters, _DbTransaction));
        }
    }
}
