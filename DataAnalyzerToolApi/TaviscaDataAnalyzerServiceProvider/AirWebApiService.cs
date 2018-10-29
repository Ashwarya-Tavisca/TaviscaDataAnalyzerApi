using CoreContracts.Models;
using CoreContracts.Models.Air;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TaviscaDataAnalyzerCache;
using TaviscaDataAnalyzerDatabase;
using TaviscaDataAnalyzerTranslator.AirTranslator;

namespace TaviscaDataAnalyzerServiceProvider
{
    public class AirWebApiService : IAirWebApiService
    {
        ICache _cache;
        IAirRepository _sqlDatabase;
        IAirTranslator _airTranslator; 
        public AirWebApiService(IAirRepository sqlDatabase,IAirTranslator airTranslator, ICache cache)
        {
            _cache = cache;
            _sqlDatabase = sqlDatabase;
            _airTranslator = airTranslator;
        }
        public  async Task<List<AirPaymentType>> AirPaymentTypeService(UIRequest uIRequest)
        {
            string result = null;           
            string data = "AirPaymentType" + uIRequest.FromDate + uIRequest.ToDate;
            result = _cache.Get(data);
            if (result == null)
            {
                DataTable dataTable =  await _sqlDatabase.AirPaymentTypeDatabase(uIRequest);
                result = _airTranslator.AirPaymentTypeTranslator(dataTable);
                _cache.Add(data, result);
            }
            List<AirPaymentType> airPaymentType = JsonConvert.DeserializeObject<List<AirPaymentType>>(result);
            return airPaymentType;
        }

        public async Task<List<DatesWithBookings>> BookingsWithinDateRangeInfoService(UIRequest uIRequest)
        {
            string result = null;
            string data = "BookingsWithinDateRange" + uIRequest.FromDate + uIRequest.ToDate;
            result = _cache.Get(data);
            if (result == null)
            {
                DataTable dataTable = await _sqlDatabase.BookingsWithinDateRangeInfoDatabase(uIRequest);
                result = _airTranslator.BookingsWithinDateRangeInfoTranslator(dataTable);
                _cache.Add(data, result);
            }
            List<DatesWithBookings> dateWithBookings = JsonConvert.DeserializeObject<List<DatesWithBookings>>(result);
            return dateWithBookings;
        }

        public async Task<List<BookingsForSpecificTrip>> BookingsForSpecificTripService(TripBookingRequest uIRequest)
        {
            string result = null;
            string data = "BookingInfoForTrip" + uIRequest.ArrivalAirportCode + uIRequest.FromDate + uIRequest.ToDate + uIRequest.ArrivalAirportCode;
            result = _cache.Get(data);
            if (result == null)
            {
                DataTable dataTable = await _sqlDatabase.BookingsForSpecificTripDatabase(uIRequest);
                result = _airTranslator.BookingsForSpecificTripTranslator(dataTable);
                _cache.Add(data, result);
            }
            List<BookingsForSpecificTrip> bookingsForSpecificTrips = JsonConvert.DeserializeObject<List<BookingsForSpecificTrip>>(result);
            return bookingsForSpecificTrips;
        }

        public async  Task<FailureCount> FailureCountInfoService(UIRequest uIRequest)
        {
            string result = null;
            string data = "AirFailureCount" + uIRequest.FromDate + uIRequest.ToDate;
            result = _cache.Get(data);
            if (result == null)
            {
                DataTable dataTable = await _sqlDatabase.AirFailureCountDatabase(uIRequest);
                result = _airTranslator.AirFailureCountTranslator(dataTable);
                _cache.Add(data, result);
            }
            FailureCount failureCount = JsonConvert.DeserializeObject<FailureCount>(result);
            return failureCount;
        }

        public async Task<List<MarketingAirlineBookings>> MarketingAirlineBookingsInfoService(UIRequest uIRequest)
        {
            string result = null;
            string data = "MarketingAirLine" + uIRequest.FromDate + uIRequest.ToDate;
            result = _cache.Get(data);
            if (result == null)
            {
                DataTable dataTable = await _sqlDatabase.MarketingAirlineBookingsInfoDatabase(uIRequest);
                result = _airTranslator.MarketingAirlineBookingsInfoTranslator(dataTable);
                _cache.Add(data, result);
            }
            List<MarketingAirlineBookings> marketingAirlineBookings = JsonConvert.DeserializeObject<List<MarketingAirlineBookings>>(result);
            return marketingAirlineBookings;
        }

        public async Task<List<TotalBookings>> TotalBookingsInfoService()
        {
            string result = null;
            string data = "AirTotalBookingsCount";
            result = _cache.Get(data);
            if (result == null)
            {
                DataTable dataTable = await _sqlDatabase.TotalBookingsInfoDatabase();
                result = _airTranslator.TotalBookingsInfoTranslator(dataTable);
                _cache.Add(data, result);
            }
            List<TotalBookings> totatlBookings = JsonConvert.DeserializeObject<List<TotalBookings>>(result);
            return totatlBookings;
        }
        public async Task<AirportsWithCodes> ListOfAirportsWithCodeService()
        {
            string result = null;
            string data = "AirPortsWithCodes";
            result = _cache.Get(data);
            if (result == null)
            {
                DataTable dataTable = await _sqlDatabase.ListOfAirportsWithCodeDatabase();
                result = _airTranslator.ListOfAirportsWithCodeTranslator(dataTable);
                _cache.Add(data, result);
            }
            AirportsWithCodes airportsWithCodes = JsonConvert.DeserializeObject<AirportsWithCodes>(result);
            return airportsWithCodes;
        }
    }
}
