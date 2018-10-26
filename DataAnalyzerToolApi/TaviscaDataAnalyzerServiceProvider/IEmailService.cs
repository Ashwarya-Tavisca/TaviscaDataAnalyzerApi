using CoreContracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaviscaDataAnalyzerServiceProvider
{
    public interface IEmailService
    {
        void generatingMail(RecipientDetails details);
    }
}
