using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
using System.Collections.Generic;

namespace NagarPalika.Application.Queries.Employees
{
    public class GetAllEmployeeQuery : PagingRquestModel, IRequest<PagingModel<EmployeeVM>>
    {

    }
}
