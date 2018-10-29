using CoreContracts.Models;
using System.Data;
using System.Threading.Tasks;

namespace TaviscaDataAnalyzerDatabase
{
    public interface IHotelRepository
    {
        Task<DataTable> GetAllLocationsDatabase();
        Task<DataTable> HotelsAtALocationWithDatesDatabases(UIRequest query);
        Task<DataTable> SupplierNamesWithDatesDatabase(UIRequest query);
        Task<DataTable> HotelNameWithDatesDatabases(UIRequest query);
        Task<DataTable> BookingDatesDatabase(UIRequest query);
        Task<DataTable> FailureCountDataBase(UIRequest query);
        Task<DataTable> PaymentDetailsDatabase(UIRequest query);
        Task<DataTable> TotalHotelBookingsDataBase();
    }
}
