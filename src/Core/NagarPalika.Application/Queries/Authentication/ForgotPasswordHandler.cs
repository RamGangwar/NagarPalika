using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NagarPalika.Application.Commands.User;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Helper;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Queries.Authentication
{
    public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordQuery, ResponseModel>
    {

        private readonly IUnitofWork _unitofWork;
        private readonly IEmailRepository _emailRepository;
        private readonly ILogger<ForgotPasswordHandler> _logger;

        private readonly DomainServiceOptions _domainoption;


        public ForgotPasswordHandler(IUnitofWork unitofWork, IEmailRepository emailRepository, ILogger<ForgotPasswordHandler> logger, IOptionsMonitor<DomainServiceOptions> optionsMonitor)
        {

            _unitofWork = unitofWork;
            _emailRepository = emailRepository;
            _logger = logger;
            _domainoption = optionsMonitor.CurrentValue;
        }
        public async Task<ResponseModel> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitofWork.Employee.GetByEmail(request.Email);
            _logger.LogInformation(nameof(Handle), user);

            if (user != null)
            {
                string body = _emailRepository.ReadEmailTemplate("ForgotPassword.html");
                body = body.Replace("$username$", user.EmployeeName);
                string link = _domainoption.ForgotPassword + "?uid=" + user.EmployeeId.ToString();
                body = body.Replace("$resetpassworlink$", link);
                bool result = await _emailRepository.SendEmail(user.EmailId, body, "Strings Forgot password");
                return new ResponseModel { Succeeded = result ? true : false, Message = result ? "Forgot password link has been sent on emailaddress" : "error occurs" };
            }
            else
            {
                return new ResponseModel { Succeeded=false, Message = "Invalid email" };
            }
        }
    }
}
