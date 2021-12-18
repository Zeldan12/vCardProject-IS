using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestBank.Models
{
    public class Transaction
    {
        public string DestinationEmail { get; set; }
        public double Ammount { get; set; }
        public string Password { get; set; }
    }
}