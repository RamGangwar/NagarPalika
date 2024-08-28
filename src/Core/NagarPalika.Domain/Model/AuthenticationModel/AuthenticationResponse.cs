using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NagarPalika.Domain.Model.AuthenticationModel
{
    public class AuthenticationResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public int RoleId { get; set; }
        [JsonIgnore]
        public string UserName { get; set; }
        [JsonIgnore]
        public string UserFullName { get; set; }
        [JsonIgnore]
        public string Designations { get; set; }
        [JsonIgnore]
        public string Picture { get; set; }
    }
}
