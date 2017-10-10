using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IRouteManager : IService
    {
         Task<string> GetAdressAsync(double latitude, double longitude);
         double CalculateDistance(double startLatitude, double startLongitude,
            double endLatitude, double endLongitude);
    }
}