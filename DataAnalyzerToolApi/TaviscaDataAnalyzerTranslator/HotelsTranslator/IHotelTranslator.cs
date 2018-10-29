using System.Data;

namespace TaviscaDataAnalyzerTranslator.HotelsTranslator
{
    public interface IHotelTranslator
    {
        string GetAllLocationsTranslator(DataTable dataTable);
        string HotelsAtALocationWithDatesTranslator(DataTable dataTable);
        string SupplierNamesWithDatesTranslator(DataTable dataTable);
        string HotelNameWithDatesTranslator(DataTable dataTable);
        string BookingDatesTranslator(DataTable dataTable);
        string FailureCountTranslator(DataTable dataTable);
        string PaymentDetailsTranslator(DataTable dataTable);
        string TotalHotelBookingsTranslator(DataTable dataTable);
    }
}
