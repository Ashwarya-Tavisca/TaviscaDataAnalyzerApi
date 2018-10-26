using Newtonsoft.Json;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using CoreContracts.Models;
using CoreContracts.Models.Hotels;

namespace TaviscaDataAnalyzerDatabase
{
    public class HotelSqlDatabase : IHotelRepository
    {
        SqlConnection _sqlConnection;
        ISqlConnector _sqlConnector;
        public HotelSqlDatabase(ISqlConnector sqlConnector)
        {
            _sqlConnector = sqlConnector;
            _sqlConnection = _sqlConnector.ConnectionEstablisher();
        }

        public DataTable QueryExecuter(string query)
        {
            SqlCommand command = new SqlCommand(query, _sqlConnection)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            _sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            _sqlConnection.Close();
            return dataTable;
        }
        public DataTable GetAllLocationsDatabase()
        {
            string query = $"SELECT DISTINCT(t3.City)FROM TripFolders t1 JOIN TripProducts t2 ON t1.FolderId = t2.TripFolderId JOIN HotelSegments t3 ON t2.Id = t3.TripProductId ;";
            DataTable dataTable = QueryExecuter(query);
            return dataTable;
        }

        public DataTable HotelsAtALocationWithDatesDatabases(UIRequest queryFormat)
        {
            string query = $"SELECT (t3.City),(t3.HotelName),Count(t3.City) as Bookings FROM TripFolders t1 JOIN TripProducts t2 ON t1.FolderId = t2.TripFolderId JOIN HotelSegments t3 ON t2.Id = t3.TripProductId JOIN PassengerSegments t4 ON t4.TripProductId=t2.Id where t3.StayPeriodStart between '{queryFormat.FromDate}' and '{queryFormat.ToDate}' and t2.ProductType='Hotel'  and t4.BookingStatus='Purchased' group by t3.HotelName,t3.city,t3.StayPeriodStart;";
            DataTable dataTable = QueryExecuter(query);
            return dataTable;
        }
        public DataTable HotelNameWithDatesDatabases(UIRequest queryFormat)
        {
            string query = $"SELECT (t3.HotelName),Count(t3.City) as Bookings FROM TripFolders t1 JOIN TripProducts t2 ON t1.FolderId = t2.TripFolderId JOIN HotelSegments t3 ON t2.Id = t3.TripProductId JOIN PassengerSegments t4 ON t4.TripProductId=t2.Id where t3.StayPeriodStart between '{queryFormat.FromDate}' and '{queryFormat.ToDate}'  and t3.City='{queryFormat.Filter}' and t4.BookingStatus='Purchased' and t2.ProductType='Hotel' group by t3.HotelName,t3.StayPeriodStart ;";
            DataTable dataTable = QueryExecuter(query);
            return dataTable;
        }
        public DataTable SupplierNamesWithDatesDatabase(UIRequest queryFormat)
        {
            string query = $"SELECT (t3.SupplierFamily),Count(t3.City) as Bookings FROM TripFolders t1 JOIN TripProducts t2 ON t1.FolderId = t2.TripFolderId JOIN HotelSegments t3 ON t2.Id = t3.TripProductId JOIN PassengerSegments t4 ON t4.TripProductId=t2.Id where t3.StayPeriodStart between '{queryFormat.FromDate}' and '{queryFormat.ToDate}' and t3.City='{queryFormat.Filter}' and t4.BookingStatus='Purchased' and t2.ProductType='Hotel' group by t3.SupplierFamily,t3.city,t3.StayPeriodStart ;";
            DataTable dataTable = QueryExecuter(query);
            return dataTable;
        }
        public DataTable FailureCountDataBase(UIRequest queryFormat)
        {
            string query = $"SELECT COUNT(t3.BookingStatus) as Failure FROM HotelSegments t1 JOIN TripProducts t2 ON t1.TripProductId = t2.Id JOIN PassengerSegments  t3 ON t2.Id = t3.TripProductId where t2.ModifiedDate between '{queryFormat.FromDate}' and '{queryFormat.ToDate}' and t3.BookingStatus ='Planned' and t2.ProductType='Hotel' and t1.City='{queryFormat.Filter}';";
            DataTable dataTable = QueryExecuter(query);
            return dataTable;
        }

        public DataTable PaymentDetailsDatabase(UIRequest queryFormat)
        {
            string query = $"SELECT t3.PaymentType,Count(t3.PaymentType) as Bookings   FROM TripProducts t1 JOIN TripFolders t2 ON t1.TripFolderId=t2.FolderId JOIN Payments t3 ON t2.FolderId=t3.TripFolderId JOIN PassengerSegments t4 ON t1.Id=t4.TripProductId JOIN HotelSegments t5 ON t5.TripProductId = t1.Id where t5.City='{queryFormat.Filter}' and t1.ModifiedDate between  '{queryFormat.FromDate}' and '{queryFormat.ToDate}' and t1.ProductType='Hotel' and t4.BookingStatus='Purchased' and t1.ProductType='Hotel' group by t3.PaymentType; ";
            DataTable dataTable = QueryExecuter(query);
            return dataTable;
        }

        public DataTable BookingDatesDatabase(UIRequest queryFormat)
        {
            string query = $"SELECT  t1.ModifiedDate ,COUNT(t1.ModifiedDate) AS Bookings FROM TripProducts t1 JOIN PassengerSegments t2 ON t1.Id=t2.TripProductId JOIN  HotelSegments t3 ON t3.TripProductId=t1.Id where t1.ProductType='Hotel' AND t2.BookingStatus='Purchased' AND  t3.City='{queryFormat.Filter}' AND t1.ModifiedDate between '{queryFormat.FromDate}' and '{queryFormat.ToDate}' group by t1.ModifiedDate ;  ";
            DataTable dataTable = QueryExecuter(query);
            return dataTable;
        }

        public DataTable TotalHotelBookingsDataBase()
        {
            string query = $"SELECT t2.BookingStatus ,COUNT(t2.BookingStatus) As AllBookings FROM TripProducts t1 JOIN PassengerSegments t2 ON t1.Id=t2.TripProductId where t1.ProductType='Hotel' group by t2.BookingStatus;";
            DataTable dataTable = QueryExecuter(query);
            return dataTable;
        }
    }
}

