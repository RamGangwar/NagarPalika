using Dapper;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Data.Repository
{
    public class RefreshTokensRepository : GenericRepository<RefreshTokens>, IRefreshTokensRepository
    {
        public RefreshTokensRepository(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<RefreshTokens> GetByToken(string Token, string iPAddress)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select * from RefreshTokens where AccessToken=@Token and IpAddress=@iPAddress");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Token", Token);
            parameters.Add("iPAddress", iPAddress);
            return (await _DbConnection.QueryAsync<RefreshTokens>(sb.ToString(), parameters, _DbTransaction)).FirstOrDefault();
        }
        public async Task<RefreshTokens> GetDetail(string ExpiredToken,
                string RefreshToken ,string IpAddress)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select * from RefreshTokens where IsInvalidated=0 and  AccessToken=@ExpiredToken and IpAddress=@IpAddress and RefreshToken=@RefreshToken ");
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("IpAddress", IpAddress);
            parameters.Add("ExpiredToken", ExpiredToken);
            parameters.Add("RefreshToken", RefreshToken);
            return (await _DbConnection.QueryAsync<RefreshTokens>(sb.ToString(), parameters, _DbTransaction)).FirstOrDefault();
        }
    }
}
