using NagarPalika.Domain.Model;
using System.Threading.Tasks;

namespace NagarPalika.Application.OtherRepository
{
    public interface IGeoLocationRepository
    {
        Task<GoogleAddressModel> GetGEOLocation(string lati, string longi);
    }
}
