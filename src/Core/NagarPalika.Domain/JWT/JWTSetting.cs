using System;
using System.Collections.Generic;
using System.Text;

namespace NagarPalika.Domain.JWT
{
    public  class JWTSetting
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
        public double RefreshTokanDuration { get; set; }
    }
}
