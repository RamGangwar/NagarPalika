using MediatR;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model;
using NagarPalika.Domain.Model.AuthenticationModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NagarPalika.Application.Commands.Authentication
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenRequest, ResponseModel<AuthenticationResponse>>
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IJWTService _jWTService;

        public RefreshTokenHandler(IUnitofWork unitofWork, IJWTService jWTService)
        {
            _unitofWork = unitofWork;
            _jWTService = jWTService;
        }

        public async Task<ResponseModel<AuthenticationResponse>> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {

            var token = GetJwtToken(request.ExpiredToken);
            var userRefreshToken = await _unitofWork.RefreshToken.GetDetail(request.ExpiredToken, request.RefreshToken, request.IpAddress);

            AuthenticationResponse response = ValidateDetails(token, userRefreshToken);
            if (!response.IsSuccess)
                return new ResponseModel<AuthenticationResponse> { Data = response, Succeeded=false, Message = response.Message };

            await _unitofWork.RefreshToken.Update(userRefreshToken);

            var userName = token.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.NameId).Value;
            var authResponse = await _jWTService.GetRefreshTokenAsync(request.IpAddress, userRefreshToken.UserId,
                userName);
            return new ResponseModel<AuthenticationResponse> { Data = authResponse, Succeeded=true, Message = "success" };
        }
        private AuthenticationResponse ValidateDetails(JwtSecurityToken token, RefreshTokens userRefreshToken)
        {
            if (userRefreshToken == null)
                return new AuthenticationResponse { IsSuccess = false, Message = "Invalid Token Details." };
            if (token.ValidTo > DateTime.UtcNow)
                return new AuthenticationResponse { IsSuccess = false, Message = "Token not expired." };
            if (userRefreshToken.ExpiredDate < DateTime.UtcNow)
                return new AuthenticationResponse { IsSuccess = false, Message = "Refresh Token Expired" };
            return new AuthenticationResponse { IsSuccess = true };
        }

        private JwtSecurityToken GetJwtToken(string expiredToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.ReadJwtToken(expiredToken);
        }
    }
}
