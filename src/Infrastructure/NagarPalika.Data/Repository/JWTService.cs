using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NagarPalika.Application.Commands.Authentication;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.JWT;
using NagarPalika.Domain.Model.AuthenticationModel;
using NagarPalika.Domain.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NagarPalika.Data.Repository
{
    public class JWTService : IJWTService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IEncryptRepository _encryptRepository;
        private readonly JWTSetting _jwtSettings;
        public JWTService(IUnitofWork unitofWork, IEncryptRepository encryptRepository, IOptionsMonitor<JWTSetting> optionsMonitor)
        {
            _unitofWork = unitofWork;
            _encryptRepository = encryptRepository;
            _jwtSettings = optionsMonitor.CurrentValue;
        }

        public async Task<AuthenticationResponse> GetRefreshTokenAsync(string ipAddress, int userId, string userName)
        {
            var refreshToken = await GenerateRefreshToken();
            var accessToken = await GenerateToken(userName, userId);
            return new AuthenticationResponse { AccessToken = accessToken, RefreshToken = refreshToken, IsSuccess = true, Message = "Success" };

            await SaveTokenDetails(ipAddress, userId, accessToken, refreshToken);
        }

        public async Task<AuthenticationResponse> GetTokenAsync(AuthenticationRequest AuthenticationRequest, string ipAddress)
        {
            var user = await _unitofWork.Employee.GetDuplicateByUserName(0, AuthenticationRequest.Username);
            AuthenticationResponse response = new AuthenticationResponse();
            //_encryptRepository.Decrypt(user.Password)
            if (user != null && user.Password == AuthenticationRequest.Password)
            {
                string tokenString = await GenerateToken(user.UserName, user.EmployeeId);
                string refreshToken = await GenerateRefreshToken();
                var desig = await _unitofWork.Designations.GetById(user.DesignationId);
                return new AuthenticationResponse { AccessToken = tokenString, RefreshToken = refreshToken, IsSuccess = true, Message = "Success", UserFullName = user.EmployeeName, UserName = user.UserName, UserId = user.EmployeeId, RoleId = user.RoleId, Designations = desig.DesignationName,Picture= string.IsNullOrEmpty(user.ProfilePicURL)? "../img/profile-img.jpg" : user.ProfilePicURL };

                await SaveTokenDetails(ipAddress, user.EmployeeId, tokenString, refreshToken);
            }
            return new AuthenticationResponse { IsSuccess = false, Message = "Invalid Credentials" };
        }

        private async Task<AuthenticationResponse> SaveTokenDetails(string ipAddress, int userId, string tokenString, string refreshToken)
        {
            var userRefreshToken = new RefreshTokens
            {
                CreatedDate = DateTime.Now,
                ExpiredDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokanDuration),
                IpAddress = ipAddress,
                RefreshToken = refreshToken,
                AccessToken = tokenString,
                UserId = userId
            };
            await _unitofWork.RefreshToken.Add(userRefreshToken);
            return new AuthenticationResponse { AccessToken = tokenString, RefreshToken = refreshToken, IsSuccess = true, Message = "Success" };
        }

        private async Task<string> GenerateRefreshToken()
        {
            var byteArray = new byte[64];
            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                cryptoProvider.GetBytes(byteArray);

                return Convert.ToBase64String(byteArray);
            }
        }

        private async Task<string> GenerateToken(string userName, int userId)
        {
            var jwtKey = _jwtSettings.Key;
            var keyBytes = Encoding.ASCII.GetBytes(jwtKey);

            var tokenHandler = new JwtSecurityTokenHandler();

            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userName),
                    new Claim("UserId", userId.ToString()),
                    new Claim("Expire", DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes).ToString())

                }),
                Expires = DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                Audience = _jwtSettings.Audience,
                Issuer = _jwtSettings.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),
               SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(descriptor);
            string tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        public async Task<bool> IsTokenValid(string accessToken, string ipAddress)
        {
            var isValid = await _unitofWork.RefreshToken.GetByToken(accessToken, ipAddress) != null;
            return await Task.FromResult(isValid);
        }

    }
}
