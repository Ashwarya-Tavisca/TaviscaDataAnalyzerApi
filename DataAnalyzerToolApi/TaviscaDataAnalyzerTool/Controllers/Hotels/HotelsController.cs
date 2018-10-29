using Microsoft.AspNetCore.Mvc;
using TaviscaDataAnalyzerServiceProvider;
using CoreContracts.Models;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAllLocations()
        {            
            return Ok(await service.GetAllLocationsService());
        }
        [HttpGet("HotelLocationWithDates")]
        public async Task<IActionResult> GetHotelLocationWithDates([FromQuery] string fromDate, string toDate)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate };                       
            return Ok(await service.HotelsAtALocationWithDatesService(query));
        }
        [HttpGet("HotelNamesWithDates")]
        public async Task<IActionResult> GetHotelNamesWithDates([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };           
            return Ok(await service.HotelNameWithDatesService(query));
        }
        [HttpGet("SupplierNamesWithDates")]
        public async Task<IActionResult> GetSupplierNamesWithDates([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };            
            return Ok(await service.SupplierNamesWithDatesService(query));
        }

        [HttpGet("FailureCount")]
        public async Task<IActionResult> GetFailureCount([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };            
            return Ok(await service.FailureCountService(query));
        }
        [HttpGet("PaymentType")] 
        public async  Task<IActionResult> GetPaymentType([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };
            return Ok(await service.PaymentDetailsService(query));
        }
        [HttpGet("BookingDates")]
        public async Task<IActionResult> GetBookingDates([FromQuery] string fromDate, string toDate, string location)
        {
            UIRequest query = new UIRequest { ToDate = toDate, FromDate = fromDate, Filter = location };            
            return Ok(await service.BookingDatesService(query));
        }
        [HttpGet("TotalBookings")]
        public async Task<IActionResult> GetSuccessfulCount()
        {           
            return Ok(await service.TotalHotelBookingsService());
        }
    }
}
