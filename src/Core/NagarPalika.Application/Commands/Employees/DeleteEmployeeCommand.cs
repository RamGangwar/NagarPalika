using MediatR;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Employees
{
    public class DeleteEmployeeCommand : IRequest<ResponseModel>
    {
        public int EmployeeId { get; set; }
    }
}
