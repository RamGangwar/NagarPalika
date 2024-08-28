using NagarPalika.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.Repository
{
    public interface IRefreshTokensRepository : IGenericRepository<RefreshTokens>
    {
        Task<RefreshTokens> GetByToken(string Token, string iPAddress);
        Task<RefreshTokens> GetDetail(string ExpiredToken, string RefreshToken, string IpAddress);
    }
}
