using CoreContracts.Models.Air;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TaviscaDataAnalyzerTranslator.AirTranslator
{
    public class AirTranslator : IAirTranslator
    {
        public string AirFailureCountTranslator(DataTable dataTable)
        {
            FailureCount failure = new FailureCount();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                failure.failureCount = Convert.ToInt32(dataRow["FailureCount"]);
            }
            var json = JsonConvert.SerializeObject(failure);
            return json;
        }

        public string AirPaymentTypeTranslator(DataTable dataTable)
        {
            List<AirPaymentType> list = new List<AirPaymentType>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                AirPaymentType paymentDetails = new AirPaymentType();
                paymentDetails.PaymentType = Convert.ToString(dataRow["PaymentType"]);
                paymentDetails.NumberOfBookings = Convert.ToInt32(dataRow["Bookings"]);
                list.Add(paymentDetails);
            }
            var json = JsonConvert.SerializeObject(list);
            return json;
        }

        public string BookingsForSpecificTripTranslator(DataTable dataTable)
        {
            List<BookingsForSpecificTrip> list = new List<BookingsForSpecificTrip>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                BookingsForSpecificTrip bookingsForSpecificTrip = new BookingsForSpecificTrip();
                bookingsForSpecificTrip.AirlineName = Convert.ToString(dataRow["ShortName"]);
                bookingsForSpecificTrip.NumberOfBookings = Convert.ToInt32(dataRow["Bookings"]);
                list.Add(bookingsForSpecificTrip);
            }
            var json = JsonConvert.SerializeObject(list);
            return json;
        }

        public string BookingsWithinDateRangeInfoTranslator(DataTable dataTable)
        {
            List<DatesWithBookings> list = new List<DatesWithBookings>();
            foreach (DataRow dataRow in dataTable.Rows)
            {

                DatesWithBookings datesWithBookings = new DatesWithBookings();

                string bookingDate = Convert.ToString(dataRow["ModifiedDate"]);
                if (bookingDate[2] == '/' && bookingDate[5] == '/')
                    bookingDate = bookingDate.Substring(0, 10);
                else if (bookingDate[1] == '/' && bookingDate[3] == '/')
                    bookingDate = bookingDate.Substring(0, 8);
                else
                    bookingDate = bookingDate.Substring(0, 9);
                if (list.Exists(existingAlready => existingAlready.Date == bookingDate))
                {

                    list[list.FindIndex(existingAlready => existingAlready.Date == bookingDate)].NumberOfBookings += Convert.ToInt32(dataRow["Bookings"]);
                }
                else
                {
                    datesWithBookings.Date = bookingDate;
                    datesWithBookings.NumberOfBookings = Convert.ToInt32(dataRow["Bookings"]);
                    list.Add(datesWithBookings);
                }
            }
            var json = JsonConvert.SerializeObject(list);
            return json;
        }

        public string ListOfAirportsWithCodeTranslator(DataTable dataTable)
        {
            AirportsWithCodes list = new AirportsWithCodes();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                
                string airportNameAndCode = Convert.ToString(dataRow["AirportName"])+"-"+ Convert.ToString(dataRow["AirportCode"]);
                 
                list.AirportNameWithCode.Add(airportNameAndCode);
            }
            var json = JsonConvert.SerializeObject(list);
            return json;
        }

        public string MarketingAirlineBookingsInfoTranslator(DataTable dataTable)
        {
            List<MarketingAirlineBookings> list = new List<MarketingAirlineBookings>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                MarketingAirlineBookings marketingAirline = new MarketingAirlineBookings();
                marketingAirline.AirlineName = Convert.ToString(dataRow["FullName"]);
                marketingAirline.AirLineCode = Convert.ToString(dataRow["MarketingAirlineCode"]);
                marketingAirline.NumberOfBookings = Convert.ToInt32(dataRow["Bookings"]);
                list.Add(marketingAirline);
            }
            var json = JsonConvert.SerializeObject(list);
            return json;
        }

        public string TotalBookingsInfoTranslator(DataTable dataTable)
        {
            List<TotalBookings> list = new List<TotalBookings>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                TotalBookings totalBookings = new TotalBookings();
                totalBookings.BookingStatus = Convert.ToString(dataRow["BookingStatus"]);
                totalBookings.NumberOfBookings = Convert.ToInt32(dataRow["AllBookings"]);
                list.Add(totalBookings);
            }
            var json = JsonConvert.SerializeObject(list);
            return json;
        }
    }
}
