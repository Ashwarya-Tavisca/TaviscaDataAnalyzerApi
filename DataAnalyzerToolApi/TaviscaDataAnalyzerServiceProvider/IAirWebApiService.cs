using CoreContracts.Models;
using CoreContracts.Models.Air;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaviscaDataAnalyzerServiceProvider
{
   public interface IAirWebApiService
    {
        Task<List<AirPaymentType>> AirPaymentTypeService(UIRequest uIRequest);
        Task<List<MarketingAirlineBookings>> MarketingAirlineBookingsInfoService(UIRequest uIRequest);
        Task<FailureCount> FailureCountInfoService(UIRequest uIRequest);
        Task<List<TotalBookings>> TotalBookingsInfoService();
        Task<List<DatesWithBookings>> BookingsWithinDateRangeInfoService(UIRequest uIRequest);
        Task<List<BookingsForSpecificTrip>> BookingsForSpecificTripService(TripBookingRequest uIRequest);
        Task<AirportsWithCodes> ListOfAirportsWithCodeService();
    }
}
