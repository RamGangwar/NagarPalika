using MediatR;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Localitys
{
    public class DeleteLocalityCommand : IRequest<ResponseModel>
    {
        public int LocalityId { get; set; }
    }
}
