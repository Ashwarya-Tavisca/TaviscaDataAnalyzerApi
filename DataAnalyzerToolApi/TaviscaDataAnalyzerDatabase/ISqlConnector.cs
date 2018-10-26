using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TaviscaDataAnalyzerDatabase
{
   public interface ISqlConnector
    {
        SqlConnection ConnectionEstablisher();
    }
}
