using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NagarPalika.Application.OtherRepository;
using NagarPalika.Domain.Helper;
using NagarPalika.Domain.Model;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace NagarPalika.Data.OtherRepository
{
    public class GeoLocationRepository : IGeoLocationRepository
    {
        private readonly GEOLocationOptions _locationOptions;
        private IHostingEnvironment _env;
        public GeoLocationRepository(IOptionsMonitor<GEOLocationOptions> option,
            IHostingEnvironment env)
        {
            _locationOptions = option.CurrentValue;
            _env = env;
        }
        public async Task<GoogleAddressModel> GetGEOLocation(string lati, string longi)
        {
            using(HttpClient client= new HttpClient())
            {
                string url = _locationOptions.GoogleUrl + lati + "," + longi + "&key=" + _locationOptions.Key;
                string response = await client.GetStringAsync(url);
                var json = JsonConvert.DeserializeObject<GoogleAddressModel>(response);
                return json;
            }

        }
    }
}
