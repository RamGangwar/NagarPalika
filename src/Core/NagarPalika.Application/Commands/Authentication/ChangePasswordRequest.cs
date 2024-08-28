using MediatR;
using NagarPalika.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Authentication
{
    
    public class ChangePasswordRequest:IRequest<ResponseModel>
    {
        public bool IsForgotPassword { get; set; }
        public string CurrentPassword { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
