using MediatR;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Zone
{
    public class UpdateZonesCommand : IRequest<ResponseModel>
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string ZoneCode { get; set; }
        public int DistrictId { get; set; }
        public bool IsActive { get; set; }
    }
}
