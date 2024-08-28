using NagarPalika.Application.Queries.Designations;
using NagarPalika.Application.Queries.Organization;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Repository
{
    public interface IOrganizationsRepository:IGenericRepository<Organizations>
    {
        Task<IEnumerable<OrganizationVM>> GetByPaging(GetOrganizationByFilterQuery filterQuery);
    }
}
