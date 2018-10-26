using System;
using System.Collections.Generic;
using System.Text;

namespace CoreContracts.Models.Air
{
    public class TripBookingRequest
    {
        public string ArrivalAirportCode { get; set; }
        public string DepartAirportCode { get; set; }
        public string ToDate { get; set; }
        public string FromDate { get; set; }
    }
}
