using MediatR;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Role
{
    public class DeleteRolesCommand : IRequest<ResponseModel>
    {
        public int RoleId { get; set; }
    }
}
