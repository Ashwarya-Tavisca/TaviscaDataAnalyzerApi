using CoreContracts.Models;
using CoreContracts.Models.Air;
using System.Data;

namespace TaviscaDataAnalyzerDatabase
{
    public interface IAirRepository
    {
        DataTable AirPaymentTypeDatabase(UIRequest uIRequest);
        DataTable MarketingAirlineBookingsInfoDatabase(UIRequest uIRequest);
        DataTable AirFailureCountDatabase(UIRequest uIRequest);
        DataTable TotalBookingsInfoDatabase();
        DataTable BookingsWithinDateRangeInfoDatabase(UIRequest uIRequest);
        DataTable BookingsForSpecificTripDatabase(TripBookingRequest uIRequest);
        DataTable ListOfAirportsWithCodeDatabase();
    }
}
