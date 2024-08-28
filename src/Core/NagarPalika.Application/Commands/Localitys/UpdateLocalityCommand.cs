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
    public class UpdateLocalityCommand : IRequest<ResponseModel>
    {
        public int LocalityId { get; set; }
        public string LocalityName { get; set; }
        public string LocalityCode { get; set; }
        public int WardId { get; set; }
    }
}
