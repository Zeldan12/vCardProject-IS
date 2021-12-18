using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestBank.Models
{
    public class Account
    {
        public int PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int ConfirmationCode { get; set; }
    }
}