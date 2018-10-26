using Microsoft.AspNetCore.Mvc;
using TaviscaDataAnalyzerServiceProvider;
using CoreContracts.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaviscaDataAnalyzerTool.Controllers
{
    [Route("api/Hotels/")]
    public class HotelsController : Controller
    {

        IHotelWebApiServiceProvider service;
        public HotelsController(IHotelWebApiServiceProvider _webApiServiceProvider)
        {
            service = _webApiServiceProvider;
        }

        [HttpGet("HotelLocations")]
        public object GetAllLocations()
        {            
            return service.GetAllLocationsService();
        }

        [HttpGet("HotelLocationWithDates")]

        public object GetHotelLocationWithDates([FromQuery] string fromDate, string toDate)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate };                       
            return service.HotelsAtALocationWithDatesService(query);
        }

        [HttpGet("HotelNamesWithDates")]

        public object GetHotelNamesWithDates([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };           
            return service.HotelNameWithDatesService(query);
        }

        [HttpGet("SupplierNamesWithDates")]

        public object GetSupplierNamesWithDates([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };            
            return service.SupplierNamesWithDatesService(query);
        }

        [HttpGet("FailureCount")]

        public object GetFailureCount([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };            
            return service.FailureCountService(query);
        }

        [HttpGet("PaymentType")]
        
        public object GetPaymentType([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };
            return service.PaymentDetailsService(query);
        }

        [HttpGet("BookingDates")]

        public object GetBookingDates([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };            
            return service.BookingDatesService(query);
        }

        [HttpGet("TotalBookings")]

        public object GetSuccessfulCount()
        {           
            return service.TotalHotelBookingsService();
        }
    }
}
