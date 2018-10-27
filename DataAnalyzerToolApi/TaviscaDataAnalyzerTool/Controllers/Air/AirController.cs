using CoreContracts.Models;
using CoreContracts.Models.Air;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetPaymentType([FromQuery]string fromDate, string toDate)
        {
            UIRequest uiRequest = new UIRequest { FromDate = fromDate, ToDate = toDate };
            return Ok(webApiServiceProvider.AirPaymentTypeService(uiRequest));
        }

        [HttpGet("MarketingAirlineBookingInfo")]
        public IActionResult GetMarketingAirlineBookingInfo([FromQuery] string fromDate, string toDate)
        {
            UIRequest uiRequest = new UIRequest { FromDate = fromDate, ToDate = toDate };
            return Ok(webApiServiceProvider.MarketingAirlineBookingsInfoService(uiRequest));
        }

        [HttpGet("FailureCount")]
        public IActionResult GetFailureCountInfo([FromQuery] string fromDate, string toDate)
        {
            UIRequest uiRequest = new UIRequest { FromDate = fromDate, ToDate = toDate };
            return Ok(webApiServiceProvider.FailureCountInfoService(uiRequest));
        }

        [HttpGet("TotalBookings")]
        public IActionResult GetTotalBookingsInfo()
        {
            return Ok(webApiServiceProvider.TotalBookingsInfoService());
        }


        [HttpGet("BookingsWithinDateRange")]
        public IActionResult GetBookingsWithinDateRangeInfo([FromQuery] string fromDate, string toDate)
        {
            UIRequest uiRequest = new UIRequest { FromDate = fromDate, ToDate = toDate };
            return Ok(webApiServiceProvider.BookingsWithinDateRangeInfoService(uiRequest));
        }

        [HttpGet("BookingsForSpecificTrip")]
        public IActionResult GetBookingsForSpecificTrip([FromQuery] string fromDate, string toDate, string departAirportCode, string arrivalAirportCode)
        {
            TripBookingRequest uiRequest = new TripBookingRequest { FromDate = fromDate, ToDate = toDate, ArrivalAirportCode = arrivalAirportCode, DepartAirportCode = departAirportCode };
            return Ok(webApiServiceProvider.BookingsForSpecificTripService(uiRequest));
        }

        [HttpGet("ListOfAirportsWithCode")]
        public IActionResult GetListOfAirportsWithCode()
        {
            return Ok(webApiServiceProvider.ListOfAirportsWithCodeService());
        }
    }
}
