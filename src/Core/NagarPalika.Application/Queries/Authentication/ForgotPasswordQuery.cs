using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Queries.Authentication
{
    public class ForgotPasswordQuery : IRequest <ResponseModel>
    {
        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress(ErrorMessage ="Please enter valid email")]
        public string Email { get; set; }
    }
}
