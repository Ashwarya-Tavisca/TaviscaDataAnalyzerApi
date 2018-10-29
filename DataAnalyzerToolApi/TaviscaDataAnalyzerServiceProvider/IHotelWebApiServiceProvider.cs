using CoreContracts.Models;
using CoreContracts.Models.Hotels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaviscaDataAnalyzerServiceProvider
{
    public interface IHotelWebApiServiceProvider
    {
        Task<Cities> GetAllLocationsService();
        Task<List<HotelsInALocationWithDates>> HotelsAtALocationWithDatesService(UIRequest query);
        Task<List<HotelNamesWithBookings>> HotelNameWithDatesService(UIRequest query);
        Task<List<IndividualSupplierBookings>> SupplierNamesWithDatesService(UIRequest query);
        Task<FailuresInBooking> FailureCountService(UIRequest query);
        Task<List<PaymentDetails>> PaymentDetailsService(UIRequest query);
        Task<List<HotelBookingDates>> BookingDatesService(UIRequest query);
        Task<List<TotalHotelBookings>> TotalHotelBookingsService();
    }
}
