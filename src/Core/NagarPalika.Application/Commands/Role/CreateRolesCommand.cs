using MediatR;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Role
{
    public class CreateRolesCommand : IRequest<ResponseModel<RolesVM>>
    {
        public string RoleName { get; set; }
        public int RoleId { get; set; }
    }
}
