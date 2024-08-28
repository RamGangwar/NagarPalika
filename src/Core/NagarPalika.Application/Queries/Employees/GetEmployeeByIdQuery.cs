using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Queries.Employees
{
    public class GetEmployeeByIdQuery : IRequest<ResponseModel<EmployeeVM>>
    {
        public int UserId { get; set; }
    }
}
