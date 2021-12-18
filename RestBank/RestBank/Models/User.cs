using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestBank.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
    }
}