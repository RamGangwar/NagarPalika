using MediatR;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Application.Repository;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.Model.AuthenticationModel;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using NagarPalika.Domain.JWT;
using Microsoft.Extensions.Options;
using NagarPalika.Application.UnitOfWork;

namespace NagarPalika.Application.Commands.Authentication
{
    public class AuthenticationHandler : IRequestHandler<AuthenticationRequest, ResponseModel<AuthenticationResponse>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IJWTService _jWTService;
        public AuthenticationHandler(IUnitofWork unitofWork, IJWTService jWTService)
        {
            _unitofWork = unitofWork;
            _jWTService = jWTService;
        }
        public async Task<ResponseModel<AuthenticationResponse>> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            var authResponse = await _jWTService.GetTokenAsync(request, request.IpAddress);
            if (authResponse == null)
                return new ResponseModel<AuthenticationResponse> { Data = null, Succeeded=false, Message = authResponse.Message };
            return new ResponseModel<AuthenticationResponse> { Data = authResponse, Succeeded = authResponse.IsSuccess ? true : false, Message = authResponse.Message };
        }
    }
}
