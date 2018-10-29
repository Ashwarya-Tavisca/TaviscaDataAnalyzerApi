using CoreContracts.Models;
using CoreContracts.Models.Air;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TaviscaDataAnalyzerDatabase
{
    public class AirSqlDatabase : IAirRepository
    {
        SqlConnection _sqlconnection;
        ISqlConnector _sqlConnector;
        public AirSqlDatabase(ISqlConnector sqlConnector)
        {
            _sqlConnector = sqlConnector;
            _sqlconnection = this._sqlConnector.ConnectionEstablisher();
        }
        public async Task<DataTable> QueryExecuter(string query)
        {
            SqlCommand command = new SqlCommand(query, _sqlconnection)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            await _sqlconnection.OpenAsync();
            dataAdapter.Fill(dataTable);
            _sqlconnection.Close();
            return dataTable;
        }
        public async Task<DataTable> BookingsForSpecificTripDatabase(TripBookingRequest uIRequest)
        {                      
            string query = $"SELECT  t4.ShortName ,COUNT(t4.ShortName) AS Bookings FROM TripProducts t1 JOIN PassengerSegments t2 ON t1.Id=t2.TripProductId JOIN  AirSegments t3 ON t3.TripProductId=t1.Id Join Airlines  t4 on t4.AirlineCode = t3.MarketingAirlineCode where t1.ProductType='Air' AND t2.BookingStatus='Purchased' AND t1.ModifiedDate between '{uIRequest.FromDate}' and '{uIRequest.ToDate}' and t3.DepartAirportCode='{uIRequest.DepartAirportCode}' and t3.ArriveAirportCode='{uIRequest.ArrivalAirportCode}' group by t4.ShortName;";
            DataTable dataTable = await QueryExecuter(query);
            return dataTable;                       
        }
        public async Task<DataTable> AirFailureCountDatabase(UIRequest uIRequest)
        {                        
            string query = $"SELECT COUNT(t3.BookingStatus) as FailureCount FROM AirSegments t1 JOIN TripProducts t2 ON t1.TripProductId = t2.Id JOIN PassengerSegments  t3 ON t2.Id = t3.TripProductId where t2.ModifiedDate between '{uIRequest.FromDate}' and '{uIRequest.ToDate}' and t3.BookingStatus ='Purchased' and t2.ProductType='Air' ;";
            DataTable dataTable = await QueryExecuter(query);
            return dataTable;
        }
        public async Task<DataTable> AirPaymentTypeDatabase(UIRequest uIRequest)
        {            
            string query = $"SELECT t3.PaymentType,Count(t3.PaymentType) as Bookings   FROM TripProducts t1 JOIN TripFolders t2 ON t1.TripFolderId=t2.FolderId JOIN Payments t3 ON t2.FolderId=t3.TripFolderId JOIN AirSegments t5 ON t5.TripProductId = t1.Id Join PassengerSegments t7 ON t7.TripProductId=t1.Id where t7.BookingStatus='Purchased'and t1.ModifiedDate between  '{uIRequest.FromDate}' and '{uIRequest.ToDate}'  and t1.ProductType='Air' group by t3.PaymentType; ";
            DataTable dataTable = await QueryExecuter(query);
            return dataTable;
        }
        public async Task<DataTable> BookingsWithinDateRangeInfoDatabase(UIRequest uIRequest)
        {            
            string query = $"SELECT  t1.ModifiedDate ,COUNT(t1.ModifiedDate) AS Bookings FROM TripProducts t1 JOIN PassengerSegments t2 ON t1.Id=t2.TripProductId JOIN  AirSegments t3 ON t3.TripProductId=t1.Id where t1.ProductType='Air' AND t2.BookingStatus='Purchased' AND t1.ModifiedDate between '{uIRequest.FromDate}' and '{uIRequest.ToDate}' group by t1.ModifiedDate;";
            DataTable dataTable = await QueryExecuter(query);
            return dataTable;
        }
        public async Task<DataTable> MarketingAirlineBookingsInfoDatabase(UIRequest uIRequest)
        {            
            string query = $"SELECT t4.FullName,t5.MarketingAirlineCode,Count(t5.MarketingAirlineCode) as Bookings   FROM TripProducts t1 JOIN TripFolders t2 ON t1.TripFolderId=t2.FolderId JOIN Payments t3 ON t2.FolderId=t3.TripFolderId JOIN AirSegments t5 ON t5.TripProductId = t1.Id Join Airlines t4 ON t4.AirlineCode=t5.MarketingAirlineCode Join PassengerSegments t7 ON t7.TripProductId=t1.Id where t7.BookingStatus='Purchased'and t1.ModifiedDate between  '{uIRequest.FromDate}' and '{uIRequest.ToDate}'  and t1.ProductType='Air' group by t5.MarketingAirlineCode,t4.FullName;  ";
            DataTable dataTable = await QueryExecuter(query);
            return dataTable;
        }
        public async Task<DataTable> TotalBookingsInfoDatabase()
        {            
            string query = $"SELECT t2.BookingStatus ,COUNT(t2.BookingStatus) As AllBookings FROM TripProducts t1 JOIN PassengerSegments t2 ON t1.Id=t2.TripProductId where t1.ProductType='Air' group by t2.BookingStatus;";
            DataTable dataTable = await QueryExecuter(query);
            return dataTable;
        }
        public async Task<DataTable> ListOfAirportsWithCodeDatabase()
        {            
            string query = $"Select AirportName,AirportCode from Airports;";
            DataTable dataTable = await QueryExecuter(query);
            return dataTable;
        }
    }
}
