using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreContracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaviscaDataAnalyzerServiceProvider;

namespace TaviscaDataAnalyzerTool.Controllers
{
    [Route("api/EmailSender")]
    public class EmailSenderController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailSenderController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public void Post([FromBody] RecipientDetails details)
        {
            _emailService.generatingMail(details);
        }
    }


}
