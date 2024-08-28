using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Application.Commands.User
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ResponseModel<EmployeeVM>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IEmailRepository _emailRepository;
        private readonly IEncryptRepository _encryptRepository;
        private readonly ILogger<CreateEmployeeHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICommonMethod _commonMethod;
        public CreateEmployeeHandler(IUnitofWork unitofWork, IEmailRepository emailRepository, IEncryptRepository encryptRepository, ILogger<CreateEmployeeHandler> logger, IMediator mediator, ICommonMethod commonMethod, IHttpContextAccessor httpContextAccessor)
        {

            _unitofWork = unitofWork;
            _emailRepository = emailRepository;
            _encryptRepository = encryptRepository;
            _logger = logger;
            _mediator = mediator;
            _commonMethod = commonMethod;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseModel<EmployeeVM>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {

            var duplicateuser = await _unitofWork.Employee.GetDuplicateByUserName(0, command.UserName);
            if (duplicateuser == null)
            {
                var empId = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                var model = command.Adapt<Employee>();
                model.IsActive = true;
                model.CreatedBy = Convert.ToInt32(empId);
                model.CreatedOn = DateTime.Now;
                var result = await _unitofWork.Employee.Add(model);

                var user = await _unitofWork.Employee.GetById(result);
                if (command.ProfilePic != null && command.ProfilePic.Length > 0)
                {
                    var url = await _commonMethod.SaveAttachment(user.EmployeeId, "Profile", command.ProfilePic);
                    user.ProfilePicURL = url;
                    var res = await _unitofWork.Employee.Update(user);
                }
                return new ResponseModel<EmployeeVM>
                {
                    Data = user.Adapt<EmployeeVM>(),
                    Succeeded = result > 0 ? true : false,
                    Message = result > 0 ? "Record Save Successfully." : "Fail"

                };

            }
            else
            {
                return new ResponseModel<EmployeeVM>
                {
                    Data = null,
                    Succeeded = false,
                    Message = "Record Already exists with same phone OR Email"
                };
            }
        }
    }
}
