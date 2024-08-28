using MediatR;
using NagarPalika.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace NagarPalika.Application.Commands.Zone
{
    public class DeleteZonesCommand : IRequest<ResponseModel>
    {
        [Required(ErrorMessage ="Zone Required")]
        public int ZoneId { get; set; }
    }
}
