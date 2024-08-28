using Dapper.Contrib.Extensions;
using System;

namespace NagarPalika.Domain.Entity
{
    [Table("RefreshTokens")]
    public class RefreshTokens
    {
        [Key]
        public int RefreshTokenId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }       
        public string IpAddress { get; set; }
        public int UserId { get; set; }
    }
}
