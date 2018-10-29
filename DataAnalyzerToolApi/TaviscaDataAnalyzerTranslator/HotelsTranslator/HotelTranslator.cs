using CoreContracts.Models.Hotels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TaviscaDataAnalyzerTranslator.HotelsTranslator
{
    public class HotelTranslator : IHotelTranslator
    {
        public string BookingDatesTranslator(DataTable dataTable)
        {
            List<HotelBookingDates> list = new List<HotelBookingDates>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                HotelBookingDates hotelBookingDates = new HotelBookingDates();
                string bookingDate = Convert.ToString(dataRow["ModifiedDate"]);
                if (bookingDate[2] == '/' && bookingDate[5] == '/')
                    bookingDate = bookingDate.Substring(0, 10);
                else if (bookingDate[1] == '/' && bookingDate[3] == '/')
                    bookingDate = bookingDate.Substring(0, 8);
                else
                    bookingDate = bookingDate.Substring(0, 9);
                if (list.Exists(existingAlready => existingAlready.BookingDates == bookingDate))
                {
                    list[list.FindIndex(existingAlready => existingAlready.BookingDates == bookingDate)].NumberOfBookings += Convert.ToInt32(dataRow["Bookings"]);
                }
                else
                {
                    hotelBookingDates.BookingDates = bookingDate;
                    hotelBookingDates.NumberOfBookings = Convert.ToInt32(dataRow["Bookings"]);
                    list.Add(hotelBookingDates);
                }
            }
            var json = JsonConvert.SerializeObject(list);
            return json;
        }
        public string FailureCountTranslator(DataTable dataTable)
        {
            FailuresInBooking failuresInBooking = new FailuresInBooking();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                failuresInBooking.counter = Convert.ToInt32(dataRow["Failure"]);
            }
            var json = JsonConvert.SerializeObject(failuresInBooking);
            return json;
        }
        public string GetAllLocationsTranslator(DataTable dataTable)
        {
            Cities cities = new Cities();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                cities.City.Add(Convert.ToString(dataRow["City"]));
            }
            cities.City.Sort();
            var json = JsonConvert.SerializeObject(cities);
            return json;
        }

        public string HotelNameWithDatesTranslator(DataTable dataTable)
        {
            List<HotelNamesWithBookings> list = new List<HotelNamesWithBookings>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                HotelNamesWithBookings hotelNamesWithBookings = new HotelNamesWithBookings();
                hotelNamesWithBookings.HotelName = Convert.ToString(dataRow["HotelName"]);
                hotelNamesWithBookings.Bookings = Convert.ToInt32(dataRow["Bookings"]);
                list.Add(hotelNamesWithBookings);
            }
            list.Sort((objectAccessorOne, objectAccessorTwo) => objectAccessorOne.HotelName.CompareTo(objectAccessorTwo.HotelName));
            var json = JsonConvert.SerializeObject(list);
            return json;
        }

        public string HotelsAtALocationWithDatesTranslator(DataTable dataTable)
        {
            List<HotelsInALocationWithDates> list = new List<HotelsInALocationWithDates>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                HotelsInALocationWithDates locationWithDates = new HotelsInALocationWithDates();
                HotelsAtLocation hotelAndBookings = new HotelsAtLocation();
                string city = Convert.ToString(dataRow["City"]);
                hotelAndBookings.HotelName = Convert.ToString(dataRow["HotelName"]);
                hotelAndBookings.Bookings = Convert.ToInt32(dataRow["Bookings"]);
                if (list.Exists(existingAlready => existingAlready.Place == city))
                {
                    list[list.FindIndex(existingAlready => existingAlready.Place == city)].HotelsAtParticularLocation.Add(hotelAndBookings);
                    list[list.FindIndex(existingAlready => existingAlready.Place == city)].totalBookings += hotelAndBookings.Bookings;
                }
                else
                {
                    locationWithDates.HotelsAtParticularLocation.Add(hotelAndBookings);
                    locationWithDates.Place = city;
                    locationWithDates.totalBookings += hotelAndBookings.Bookings;
                    list.Add(locationWithDates);
                }
            }
            list.Sort((objectAccessorOne, objectAccessorTwo) => objectAccessorOne.Place.CompareTo(objectAccessorTwo.Place));
            var json = JsonConvert.SerializeObject(list);
            return json;
        }

        public string PaymentDetailsTranslator(DataTable dataTable)
        {
            List<PaymentDetails> list = new List<PaymentDetails>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                PaymentDetails paymentDetails = new PaymentDetails();
                paymentDetails.PaymentType = Convert.ToString(dataRow["PaymentType"]);
                paymentDetails.NumberOfBooking = Convert.ToInt32(dataRow["Bookings"]);
                list.Add(paymentDetails);
            }
            list.Sort((objectAccessorOne, objectAccessorTwo) => objectAccessorOne.PaymentType.CompareTo(objectAccessorTwo.PaymentType));
            var json = JsonConvert.SerializeObject(list);
            return json;
        }

        public string SupplierNamesWithDatesTranslator(DataTable dataTable)
        {
            List<IndividualSupplierBookings> list = new List<IndividualSupplierBookings>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                string supplierFamilyname = Convert.ToString(dataRow["SupplierFamily"]);
                IndividualSupplierBookings supplierNamesWithBookings = new IndividualSupplierBookings();
                if (list.Exists(suppName => suppName.SupplierName == supplierFamilyname))
                {
                    list[list.FindIndex(suppName => suppName.SupplierName == supplierFamilyname)].Bookings += Convert.ToInt32(dataRow["Bookings"]);
                }
                else
                {
                    supplierNamesWithBookings.SupplierName = supplierFamilyname;
                    supplierNamesWithBookings.Bookings = Convert.ToInt32(dataRow["Bookings"]);
                    list.Add(supplierNamesWithBookings);
                }
            }
            list.Sort((objectAccessorOne, objectAccessorTwo) => objectAccessorOne.SupplierName.CompareTo(objectAccessorTwo.SupplierName));
            var json = JsonConvert.SerializeObject(list);
            return json;
        }

        public string TotalHotelBookingsTranslator(DataTable dataTable)
        {
            List<TotalHotelBookings> list = new List<TotalHotelBookings>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                TotalHotelBookings totalHotelBookings = new TotalHotelBookings();
                totalHotelBookings.Type = Convert.ToString(dataRow["BookingStatus"]);
                totalHotelBookings.Count = Convert.ToInt32(dataRow["AllBookings"]);
                list.Add(totalHotelBookings);
            }
            list.Sort((objectAccessorOne, objectAccessorTwo) => objectAccessorOne.Type.CompareTo(objectAccessorTwo.Type));
            var json = JsonConvert.SerializeObject(list);
            return json;
        }
    }
}
