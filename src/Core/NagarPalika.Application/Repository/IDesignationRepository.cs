using NagarPalika.Application.Queries.Departments;
using NagarPalika.Application.Queries.Designations;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Repository
{
    public interface IDesignationRepository : IGenericRepository<Designation>
    {
        Task<IEnumerable<DesignationVM>> GetByPaging(GetDesignationByFilterQuery filterQuery);
    }
}
