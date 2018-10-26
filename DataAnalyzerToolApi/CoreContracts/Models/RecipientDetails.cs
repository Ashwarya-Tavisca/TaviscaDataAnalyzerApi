using System;
using System.Collections.Generic;
using System.Text;

namespace CoreContracts.Models
{
    public class RecipientDetails
    {
        public string RecipientEmialId { get; set; }
        public string[] FilterName { get; set; }
        public string[][] Labels { get; set; }
        public string[][] Statistics { get; set; }
        public string[] StartDate { get; set; }
        public string[] EndDate { get; set; }
        public string[] Location { get; set; }
    }
}
