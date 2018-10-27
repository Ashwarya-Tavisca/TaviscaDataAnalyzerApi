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
        public IActionResult GetAllLocations()
        {            
            return Ok(service.GetAllLocationsService());
        }

        [HttpGet("HotelLocationWithDates")]

        public IActionResult GetHotelLocationWithDates([FromQuery] string fromDate, string toDate)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate };                       
            return Ok(service.HotelsAtALocationWithDatesService(query));
        }

        [HttpGet("HotelNamesWithDates")]

        public IActionResult GetHotelNamesWithDates([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };           
            return Ok(service.HotelNameWithDatesService(query));
        }

        [HttpGet("SupplierNamesWithDates")]

        public IActionResult GetSupplierNamesWithDates([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };            
            return Ok(service.SupplierNamesWithDatesService(query));
        }

        [HttpGet("FailureCount")]

        public IActionResult GetFailureCount([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };            
            return Ok(service.FailureCountService(query));
        }

        [HttpGet("PaymentType")]
        
        public IActionResult GetPaymentType([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };
            return Ok(service.PaymentDetailsService(query));
        }

        [HttpGet("BookingDates")]

        public IActionResult GetBookingDates([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };            
            return Ok(service.BookingDatesService(query));
        }

        [HttpGet("TotalBookings")]

        public IActionResult GetSuccessfulCount()
        {           
            return Ok(service.TotalHotelBookingsService());
        }
    }
}
