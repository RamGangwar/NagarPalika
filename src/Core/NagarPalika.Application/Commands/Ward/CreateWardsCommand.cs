using MediatR;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Ward
{
    public class CreateWardsCommand : IRequest<ResponseModel<WardsVM>>
    {
        public string WardName { get; set; }
        public int WardNo { get; set; }
        public int ZoneId { get; set; }
        public int WardId { get; set; }
    }
}
