using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.Model.Reponse;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Queries.Localitys
{
    public class GetLocalityByFilterQuery : PagingRquestModel, IRequest<PagingModel<LocalityVM>>
    {
    }
}
