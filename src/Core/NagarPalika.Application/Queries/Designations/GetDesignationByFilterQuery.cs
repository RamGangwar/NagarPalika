using MediatR;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Queries.Designations
{
    public class GetDesignationByFilterQuery : PagingRquestModel, IRequest<PagingModel<DesignationVM>>
    {

    }
}
