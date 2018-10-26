using CoreContracts.Models;
using CoreContracts.Models.Hotels;
using System.Collections.Generic;

namespace TaviscaDataAnalyzerServiceProvider
{
    public interface IHotelWebApiServiceProvider
    {
        Cities GetAllLocationsService();
        List<HotelsInALocationWithDates> HotelsAtALocationWithDatesService(UIRequest query);
        List<HotelNamesWithBookings> HotelNameWithDatesService(UIRequest query);
        List<IndividualSupplierBookings> SupplierNamesWithDatesService(UIRequest query);
        FailuresInBooking FailureCountService(UIRequest query);
        List<PaymentDetails> PaymentDetailsService(UIRequest query);
        List<HotelBookingDates> BookingDatesService(UIRequest query);
        List<TotalHotelBookings> TotalHotelBookingsService();
    }
}
