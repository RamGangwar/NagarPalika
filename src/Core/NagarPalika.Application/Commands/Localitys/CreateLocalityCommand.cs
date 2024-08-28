using MediatR;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Localitys
{
    public class CreateLocalityCommand : IRequest<ResponseModel<LocalityVM>>
    {
        public string LocalityName { get; set; }
        public string LocalityCode { get; set; }
        public int WardId { get; set; }
        public int LocalityId { get; set; }
    }
}
