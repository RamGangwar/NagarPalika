using MediatR;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Zone
{
    public class CreateZonesCommand : IRequest<ResponseModel<ZonesVM>>
    {
        public string ZoneName { get; set; }
        public string ZoneCode { get; set; }
        public int DistrictId { get; set; }
        public int ZoneId { get; set; }
    }
}
