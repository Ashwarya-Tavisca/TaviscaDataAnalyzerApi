using CoreContracts.Models;
using CoreContracts.Models.Hotels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using TaviscaDataAnalyzerCache;
using TaviscaDataAnalyzerDatabase;
using TaviscaDataAnalyzerTranslator.HotelsTranslator;

namespace TaviscaDataAnalyzerServiceProvider
{
    public class HotelWebApiServiceProvider : IHotelWebApiServiceProvider
    {
        IHotelRepository _sqlDatabase;
        ICache _cache;
        IHotelTranslator _hotelTranslator;
        public HotelWebApiServiceProvider(IHotelRepository sqlDatabase, IHotelTranslator hotelTranslator, ICache cache)
        {
            _cache = cache;
            _sqlDatabase = sqlDatabase;
            _hotelTranslator = hotelTranslator;
        }
        public List<HotelBookingDates> BookingDatesService(UIRequest query)
        {
            string result = null;
            string data = "BookingDates" + query.Filter + query.FromDate + query.ToDate;
            result = _cache.Get(data);
            if (result == null)
            {

                DataTable dataTable = _sqlDatabase.BookingDatesDatabase(query);
                result = _hotelTranslator.BookingDatesTranslator(dataTable);
                _cache.Add(data, result);
            }
            List<HotelBookingDates> hotelBookingDates = JsonConvert.DeserializeObject<List<HotelBookingDates>>(result);
            return hotelBookingDates;
        }

        public FailuresInBooking FailureCountService(UIRequest query)
        {
            string result = null;
            string data = "FailureCount";
            result = _cache.Get(data);
            if (result == null)
            {

                DataTable dataTable = _sqlDatabase.FailureCountDataBase(query);
                result = _hotelTranslator.FailureCountTranslator(dataTable);
                _cache.Add(data, result);
            }
            FailuresInBooking FailureCount = JsonConvert.DeserializeObject<FailuresInBooking>(result);
            return FailureCount;
        }

        public Cities GetAllLocationsService()
        {
            string result = null;
            string data = "AllLocations";
            result = _cache.Get(data);
            if (result == null)
            {

                DataTable dataTable = _sqlDatabase.GetAllLocationsDatabase();
                result = _hotelTranslator.GetAllLocationsTranslator(dataTable);
                _cache.Add(data, result);
            }
            Cities ListOfCities = JsonConvert.DeserializeObject<Cities>(result);
            return ListOfCities;
        }

        public List<HotelNamesWithBookings> HotelNameWithDatesService(UIRequest query)
        {
            string result = null;
            string data = query.ToDate + query.Filter + query.FromDate;
            result = _cache.Get(data);
            if (result == null)
            {

                DataTable dataTable = _sqlDatabase.HotelNameWithDatesDatabases(query);
                result = _hotelTranslator.HotelNameWithDatesTranslator(dataTable);
                _cache.Add(data, result);
            }
            List<HotelNamesWithBookings> ListOfHotelNamesWithDates = JsonConvert.DeserializeObject<List<HotelNamesWithBookings>>(result);
            return ListOfHotelNamesWithDates;
        }

        public List<HotelsInALocationWithDates> HotelsAtALocationWithDatesService(UIRequest query)
        {
            string result = null;
            string data = query.ToDate + query.FromDate;
            result = _cache.Get(data);
            if (result == null)
            {

                DataTable dataTable = _sqlDatabase.HotelsAtALocationWithDatesDatabases(query);
                result = _hotelTranslator.HotelsAtALocationWithDatesTranslator(dataTable);
                _cache.Add(data, result);
            }
            List<HotelsInALocationWithDates> ListOfHotelsWithDates = JsonConvert.DeserializeObject<List<HotelsInALocationWithDates>>(result);
            return ListOfHotelsWithDates;
        }

        public List<PaymentDetails> PaymentDetailsService(UIRequest query)
        {
            string result = null;
            string data = query.ToDate + query.FromDate + "Payment" + query.Filter;
            result = _cache.Get(data);
            if (result == null)
            {

                DataTable dataTable = _sqlDatabase.PaymentDetailsDatabase(query);
                result = _hotelTranslator.PaymentDetailsTranslator(dataTable);
                _cache.Add(data, result);
            }
            List<PaymentDetails> payment = JsonConvert.DeserializeObject<List<PaymentDetails>>(result);
            return payment;
        }

        public List<IndividualSupplierBookings> SupplierNamesWithDatesService(UIRequest query)
        {
            string result = null;
            string data = query.ToDate + query.FromDate + query.Filter;
            result = _cache.Get(data);
            if (result == null)
            {

                DataTable dataTable = _sqlDatabase.SupplierNamesWithDatesDatabase(query);
                result = _hotelTranslator.SupplierNamesWithDatesTranslator(dataTable);
                _cache.Add(data, result);
            }
            List<IndividualSupplierBookings> ListOfSuppliers = JsonConvert.DeserializeObject<List<IndividualSupplierBookings>>(result);
            return ListOfSuppliers;
        }

        public List<TotalHotelBookings> TotalHotelBookingsService()
        {
            string result = null;
            string data = "TotalHotelBookings";
            result = _cache.Get(data);
            if (result == null)
            {

                DataTable dataTable = _sqlDatabase.TotalHotelBookingsDataBase();
                result = _hotelTranslator.TotalHotelBookingsTranslator(dataTable);
                _cache.Add(data, result);
            }
            List<TotalHotelBookings> totalHotelBookings = JsonConvert.DeserializeObject<List<TotalHotelBookings>>(result);
            return totalHotelBookings;
        }
    }
}
