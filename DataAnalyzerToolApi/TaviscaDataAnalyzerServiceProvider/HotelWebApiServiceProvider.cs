using CoreContracts.Models;
using CoreContracts.Models.Hotels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
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
        public async Task<List<HotelBookingDates>> BookingDatesService(UIRequest query)
        {
            string result = null;
            string redisKey = "BookingDates" + query.Filter + query.FromDate + query.ToDate;
            result = _cache.Get(redisKey);
            if (result == null)
            {
                DataTable dataTable = await _sqlDatabase.BookingDatesDatabase(query);
                result = _hotelTranslator.BookingDatesTranslator(dataTable);
                _cache.Add(redisKey, result);
            }
            List<HotelBookingDates> hotelBookingDates = JsonConvert.DeserializeObject<List<HotelBookingDates>>(result);
            return hotelBookingDates;
        }

        public async Task<FailuresInBooking> FailureCountService(UIRequest query)
        {
            string result = null;
            string redisKey = "FailureCount";
            result = _cache.Get(redisKey);
            if (result == null)
            {
                DataTable dataTable = await  _sqlDatabase.FailureCountDataBase(query);
                result = _hotelTranslator.FailureCountTranslator(dataTable);
                _cache.Add(redisKey, result);
            }
            FailuresInBooking FailureCount = JsonConvert.DeserializeObject<FailuresInBooking>(result);
            return FailureCount;
        }

        public async Task<Cities> GetAllLocationsService()
        {
            string result = null;
            string redisKey = "AllLocations";
            result = _cache.Get(redisKey);
            if (result == null)
            {
                DataTable dataTable = await _sqlDatabase.GetAllLocationsDatabase();
                result = _hotelTranslator.GetAllLocationsTranslator(dataTable);
                _cache.Add(redisKey, result);
            }
            Cities ListOfCities = JsonConvert.DeserializeObject<Cities>(result);
            return ListOfCities;
        }

        public async Task<List<HotelNamesWithBookings>> HotelNameWithDatesService(UIRequest query)
        {
            string result = null;
            string redisKey = query.ToDate + query.Filter + query.FromDate;
            result = _cache.Get(redisKey);
            if (result == null)
            {
                DataTable dataTable = await _sqlDatabase.HotelNameWithDatesDatabases(query);
                result = _hotelTranslator.HotelNameWithDatesTranslator(dataTable);
                _cache.Add(redisKey, result);
            }
            List<HotelNamesWithBookings> ListOfHotelNamesWithDates = JsonConvert.DeserializeObject<List<HotelNamesWithBookings>>(result);
            return ListOfHotelNamesWithDates;
        }

        public async Task<List<HotelsInALocationWithDates>> HotelsAtALocationWithDatesService(UIRequest query)
        {
            string result = null;
            string redisKey = query.ToDate + query.FromDate;
            result = _cache.Get(redisKey);
            if (result == null)
            {
                DataTable dataTable = await _sqlDatabase.HotelsAtALocationWithDatesDatabases(query);
                result = _hotelTranslator.HotelsAtALocationWithDatesTranslator(dataTable);
                _cache.Add(redisKey, result);
            }
            List<HotelsInALocationWithDates> ListOfHotelsWithDates = JsonConvert.DeserializeObject<List<HotelsInALocationWithDates>>(result);
            return ListOfHotelsWithDates;
        }

        public async Task<List<PaymentDetails>> PaymentDetailsService(UIRequest query)
        {
            string result = null;
            string redisKey = query.ToDate + query.FromDate + "Payment" + query.Filter;
            result = _cache.Get(redisKey);
            if (result == null)
            {
                DataTable dataTable = await _sqlDatabase.PaymentDetailsDatabase(query);
                result = _hotelTranslator.PaymentDetailsTranslator(dataTable);
                _cache.Add(redisKey, result);
            }
            List<PaymentDetails> payment = JsonConvert.DeserializeObject<List<PaymentDetails>>(result);
            return payment;
        }

        public async Task<List<IndividualSupplierBookings>> SupplierNamesWithDatesService(UIRequest query)
        {
            string result = null;
            string redisKey = query.ToDate + query.FromDate + query.Filter;
            result = _cache.Get(redisKey);
            if (result == null)
            {
                DataTable dataTable = await _sqlDatabase.SupplierNamesWithDatesDatabase(query);
                result = _hotelTranslator.SupplierNamesWithDatesTranslator(dataTable);
                _cache.Add(redisKey, result);
            }
            List<IndividualSupplierBookings> ListOfSuppliers = JsonConvert.DeserializeObject<List<IndividualSupplierBookings>>(result);
            return ListOfSuppliers;
        }

        public async Task<List<TotalHotelBookings>> TotalHotelBookingsService()
        {
            string result = null;
            string redisKey = "TotalHotelBookings";
            result = _cache.Get(redisKey);
            if (result == null)
            {
                DataTable dataTable = await _sqlDatabase.TotalHotelBookingsDataBase();
                result = _hotelTranslator.TotalHotelBookingsTranslator(dataTable);
                _cache.Add(redisKey, result);
            }
            List<TotalHotelBookings> totalHotelBookings = JsonConvert.DeserializeObject<List<TotalHotelBookings>>(result);
            return totalHotelBookings;
        }
    }
}
