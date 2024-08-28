using MediatR;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Designations
{
    public class CreateDesignationCommand:IRequest<ResponseModel<DesignationVM>>
    {
        public string DesignationName { get; set; }
        public int DesignationLevel { get; set; }
        public int DesignationId { get; set; }
    }
}
