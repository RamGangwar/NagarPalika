using MediatR;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Ward
{
    public class DeleteWardsCommand : IRequest<ResponseModel>
    {
        [Required(ErrorMessage ="Ward Required")]
        public int WardId { get; set; }
    }
}
