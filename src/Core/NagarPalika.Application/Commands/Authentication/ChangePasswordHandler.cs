using MediatR;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;

namespace NagarPalika.Application.Commands.Authentication
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, ResponseModel>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IEncryptRepository _encryptRepository;
        public ChangePasswordHandler(IUnitofWork unitofWork, IEncryptRepository encryptRepository)
        {
            _unitofWork = unitofWork;
            _encryptRepository = encryptRepository;
        }
        public async Task<ResponseModel> Handle(ChangePasswordRequest req, CancellationToken cancellationToken)
        {   
            bool res = false;
            var user = new Employee();
            if (req.UserId > 0)
            {
                user = await _unitofWork.Employee.GetById(req.UserId);
            }
            else if (!string.IsNullOrEmpty(req.Email))
            {
                user = await _unitofWork.Employee.GetByEmail(req.Email);
            }
            else
            {
                return new ResponseModel{ Message = "Invalid UserId or Email",  };
            }
            if (user != null && user.EmployeeId > 0)
            {
                if (req.IsForgotPassword)
                {
                    string pss = req.NewPassword;//_encryptRepository.Encrypt(req.NewPassword);
                    user.Password = pss;
                    await _unitofWork.Employee.Update(user);
                    res = true;
                }
                else
                {
                    string currpwd = user.Password;//_encryptRepository.Decrypt(user.Password);


                     if (currpwd != req.CurrentPassword) {
                        return new ResponseModel { Succeeded=false, Message = "Incorrect current password" };
                    }
                    else if(req.CurrentPassword == req.NewPassword)
                    {
                        return new ResponseModel { Succeeded=false, Message = " Current password and New Password can not be same" };
                    }
                    else
                    {
                        string newpss = req.NewPassword;//_encryptRepository.Encrypt(req.NewPassword);
                        user.Password = newpss;
                        await _unitofWork.Employee.Update(user);
                        res = true;
                    }
                   
                }
            }
            return new ResponseModel{ Succeeded =true, Message = "Password Changed" };

        }
    }
}
