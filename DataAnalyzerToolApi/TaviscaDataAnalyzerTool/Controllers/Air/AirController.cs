using CoreContracts.Models;
using CoreContracts.Models.Air;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaviscaDataAnalyzerServiceProvider;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaviscaDataAnalyzerTool.Controllers.Air
{
    [Route("api/Air/")]
    public class AirController : Controller
    {
        IAirWebApiService webApiServiceProvider;
        public AirController(IAirWebApiService _webApiServiceProvider)
        {
            webApiServiceProvider = _webApiServiceProvider;
        }
        [HttpGet("PaymentType")]
        public async Task<IActionResult> GetPaymentType([FromQuery]string fromDate, string toDate)
        {
            UIRequest uiRequest = new UIRequest { FromDate = fromDate, ToDate = toDate };
            return  Ok(await webApiServiceProvider.AirPaymentTypeService(uiRequest));
        }
        [HttpGet("MarketingAirlineBookingInfo")]
        public async Task<IActionResult> GetMarketingAirlineBookingInfo([FromQuery] string fromDate, string toDate)
        {
            UIRequest uiRequest = new UIRequest { FromDate = fromDate, ToDate = toDate };
            return Ok(await webApiServiceProvider.MarketingAirlineBookingsInfoService(uiRequest));
        }
        [HttpGet("FailureCount")]
        public async Task<IActionResult> GetFailureCountInfo([FromQuery] string fromDate, string toDate)
        {
            UIRequest uiRequest = new UIRequest { FromDate = fromDate, ToDate = toDate };
            return Ok(await webApiServiceProvider.FailureCountInfoService(uiRequest));
        }
        [HttpGet("TotalBookings")]
        public async Task<IActionResult> GetTotalBookingsInfo()
        {
            return Ok(await webApiServiceProvider.TotalBookingsInfoService());
        }
        [HttpGet("BookingsWithinDateRange")]
        public async Task<IActionResult> GetBookingsWithinDateRangeInfo([FromQuery] string fromDate, string toDate)
        {
            UIRequest uiRequest = new UIRequest { FromDate = fromDate, ToDate = toDate };
            return Ok(await webApiServiceProvider.BookingsWithinDateRangeInfoService(uiRequest));
        }
        [HttpGet("BookingsForSpecificTrip")]
        public async Task<IActionResult> GetBookingsForSpecificTrip([FromQuery] string fromDate, string toDate, string departAirportCode, string arrivalAirportCode)
        {
            TripBookingRequest uiRequest = new TripBookingRequest { FromDate = fromDate, ToDate = toDate, ArrivalAirportCode = arrivalAirportCode, DepartAirportCode = departAirportCode };
            return Ok(await webApiServiceProvider.BookingsForSpecificTripService(uiRequest));
        }
        [HttpGet("ListOfAirportsWithCode")]
        public async Task<IActionResult> GetListOfAirportsWithCode()
        {
            return Ok(await webApiServiceProvider.ListOfAirportsWithCodeService());
        }
    }
}
