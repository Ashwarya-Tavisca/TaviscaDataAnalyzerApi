using CoreContracts.Models;
using System.Data;

namespace TaviscaDataAnalyzerDatabase
{
    public interface IHotelRepository
    {
        DataTable GetAllLocationsDatabase();
        DataTable HotelsAtALocationWithDatesDatabases(UIRequest query);

        DataTable SupplierNamesWithDatesDatabase(UIRequest query);
        DataTable HotelNameWithDatesDatabases(UIRequest query);
        DataTable BookingDatesDatabase(UIRequest query);
        DataTable FailureCountDataBase(UIRequest query);
        DataTable PaymentDetailsDatabase(UIRequest query);

        DataTable TotalHotelBookingsDataBase();
    }
}
