using CoreContracts.Models;
using CoreContracts.Models.Air;
using System.Data;
using System.Threading.Tasks;

namespace TaviscaDataAnalyzerDatabase
{
    public interface IAirRepository
    {
        Task<DataTable> AirPaymentTypeDatabase(UIRequest uIRequest);
        Task<DataTable> MarketingAirlineBookingsInfoDatabase(UIRequest uIRequest);
        Task<DataTable> AirFailureCountDatabase(UIRequest uIRequest);
        Task<DataTable> TotalBookingsInfoDatabase();
        Task<DataTable> BookingsWithinDateRangeInfoDatabase(UIRequest uIRequest);
        Task<DataTable> BookingsForSpecificTripDatabase(TripBookingRequest uIRequest);
        Task<DataTable> ListOfAirportsWithCodeDatabase();
    }
}
