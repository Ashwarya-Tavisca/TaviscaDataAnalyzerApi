using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreContracts.Models
{
    public class UIRequest
    {
       
        public string Filter { get; set; }
        public string ToDate { get; set; }
        public string FromDate { get; set; }
    }
}