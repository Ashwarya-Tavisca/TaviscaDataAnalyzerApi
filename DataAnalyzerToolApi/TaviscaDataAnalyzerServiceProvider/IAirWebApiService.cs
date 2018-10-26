using CoreContracts.Models;
using CoreContracts.Models.Air;
using System.Collections.Generic;

namespace TaviscaDataAnalyzerServiceProvider
{
   public interface IAirWebApiService
    {
        List<AirPaymentType> AirPaymentTypeService(UIRequest uIRequest);
        List<MarketingAirlineBookings> MarketingAirlineBookingsInfoService(UIRequest uIRequest);
        FailureCount FailureCountInfoService(UIRequest uIRequest);
        List<TotalBookings> TotalBookingsInfoService();
        List<DatesWithBookings> BookingsWithinDateRangeInfoService(UIRequest uIRequest);
        List<BookingsForSpecificTrip> BookingsForSpecificTripService(TripBookingRequest uIRequest);
        AirportsWithCodes ListOfAirportsWithCodeService();
    }
}
