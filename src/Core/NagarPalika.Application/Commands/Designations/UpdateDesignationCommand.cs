using MediatR;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Designations
{
    public class UpdateDesignationCommand:IRequest<ResponseModel>
    {
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
        public int DesignationLevel { get; set; }
        public bool IsActive { get; set; }
    }
}
