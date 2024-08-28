using MediatR;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Ward
{
    public class UpdateWardsCommand : IRequest<ResponseModel>
    {
        public int WardId { get; set; }
        public string WardName { get; set; }
        public int ZoneId { get; set; }
        public bool IsActive { get; set; }
    }
}
