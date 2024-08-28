using NagarPalika.Application.Commands.Authentication;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.Model.AuthenticationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Repository
{
    public interface IJWTService 
    {
        Task<AuthenticationResponse> GetTokenAsync(AuthenticationRequest authRequest, string ipAddress);
        Task<AuthenticationResponse> GetRefreshTokenAsync(string ipAddress, int userId, string userName);
        Task<bool> IsTokenValid(string accessToken, string ipAddress);
    }
}
