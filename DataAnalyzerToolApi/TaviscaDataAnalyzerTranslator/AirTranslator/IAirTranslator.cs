using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TaviscaDataAnalyzerTranslator.AirTranslator
{
    public interface IAirTranslator
    {
        string AirPaymentTypeTranslator(DataTable serializedObject);
        string MarketingAirlineBookingsInfoTranslator(DataTable serializedObject);
        string AirFailureCountTranslator(DataTable serializedObject);
        string TotalBookingsInfoTranslator(DataTable serializedObject);
        string BookingsWithinDateRangeInfoTranslator(DataTable serializedObject);
        string BookingsForSpecificTripTranslator(DataTable serializedObject);
        string ListOfAirportsWithCodeTranslator(DataTable serializedObject);
    }
}
