using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Queries.Organization
{
    public class GetOrganizationByIdQuery : IRequest<ResponseModel<OrganizationVM>>
    {
        public int OrganizationId { get; set; }
    }
}
